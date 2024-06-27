using AutoMapper;
using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using OnDemandTutor.DataAccess.ExceptionModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        Task<ClassViewModel> GetDetail(int classId);
        Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate, int classID);
        Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate);
        Task<ClassViewModel> GetById(int idTmp);
        Task<(bool Success, string ClassName)> DeactivateClass(int idTmp);
        Task<List<ClassViewModel>> GetAllClasses();
    }

    public class ClassService : IClassService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IMapper _mapper;

        public ClassService(BE_SWP391_OnDemandTutorDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate)
        {
            var newClass = classCreate.Adapt<Class>();
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            var schedules = await _context.Schedules.Where(s => s.ClassID == newClass.ClassId)
                          .Select(x => x.Adapt<ScheduleViewModel>()).ToListAsync();

            return newClass.Adapt<ClassViewModel>();
        }

        public async Task<(bool Success, string ClassName)> DeactivateClass(int idTmp)
        {
            var classEntity = await _context.Classes.FindAsync(idTmp);
            if (classEntity == null)
            {
                throw new NotFoundException("Can not find the Class");
            }

            classEntity.Active = !classEntity.Active;
            //classEntity.Active = false;
            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();

            return (true, classEntity.ClassName);
        }

        public async Task<ClassViewModel> GetById(int idTmp)
        {
            var classEntity = await _context.Classes
                .Include(c => c.Student)
                .Include(c => c.Tutor)
                .Include(c => c.Feedback)
                .Include(c => c.Schedules)
                .FirstOrDefaultAsync(c => c.ClassId == idTmp);
            var tutor = await _context.Users.FirstOrDefaultAsync(t => t.UserId == classEntity.TutorId);
            var student = await _context.Users.FirstOrDefaultAsync(t => t.UserId == classEntity.StudentId);
            if (classEntity == null)
            {
                return null;
            }
            var classViewModel = classEntity.Adapt<ClassViewModel>();
            classViewModel.Tutor = tutor.Adapt<UserViewModel>();
            classViewModel.Student = tutor.Adapt<UserViewModel>();

            return classViewModel;


        }

        public async Task<ClassViewModel> GetDetail(int classId)
        {
            var classEntity = await _context.Classes
                .Include(c => c.Student)
                .Include(c => c.Tutor)
                .Include(c => c.Feedback)
                .Include(c => c.Schedules)
                .FirstOrDefaultAsync(c => c.ClassId == classId);

            if (classEntity == null)
            {
                throw new ModelException("id", "The Class Id is not valid. Please try again.", "400");
            }
            return new ClassViewModel
            {
                ClassId = classEntity.ClassId,
                ClassName = classEntity.ClassName,
                ClassInfo = classEntity.ClassInfo,
                ClassRequire = classEntity.ClassRequire,
                ClassAddress = classEntity.ClassAddress,
                ClassMethod = classEntity.ClassMethod,
                ClassLevel = classEntity.ClassLevel,
                ClassFee = classEntity.ClassFee,
                StudentId = classEntity?.StudentId.Value, // Assuming Student has a StudentId property
                // Assuming Student has a Name property
                TutorId = classEntity.TutorId, // Assuming Tutor has a TutorId property
                TutorName = classEntity.Tutor?.Username ?? string.Empty, // Assuming User has a Name property
                Feedback = classEntity.Feedback?.Content ?? string.Empty, // Assuming Feedback has a Content property
                Schedules = classEntity.Schedules?.Select(s => new ScheduleViewModel
                {
                    ScheduleID = s.ScheduleID,
                    Description = s.Description,
                    Title = s.Title,
                    DateOfWeek = s.DateOfWeek,
                    StartTime = s.StartTime.Value,
                    EndTime = s.EndTime.Value
                }).ToList() ?? new List<ScheduleViewModel>(), // Handle null Schedules
                CreatedDate = classEntity.CreatedDate,
                Active = classEntity.Active,
                District = classEntity.District,
                Ward = classEntity.Ward,
                City = classEntity.City,
            };
        }

        public async Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate, int classID)
        {
            var classEntity = await _context.Classes.FindAsync(classID);
            if (classEntity == null)
            {
                throw new NotFoundException("Can not find the Class");
            }
            if (classUpdate.StudentId.HasValue)
            {
                var studentExists = await _context.Users.AnyAsync(u => u.UserId == classUpdate.StudentId.Value);
                if (!studentExists)
                {
                    // You can return a custom error message or handle it differently
                    throw new NotFoundException("Can not find the StudentId");
                }
            }

            classEntity.ClassName = classUpdate.ClassName;
            classEntity.ClassInfo = classUpdate.ClassInfo;
            classEntity.ClassRequire = classUpdate.ClassRequire;
            classEntity.ClassAddress = classUpdate.ClassAddress;
            classEntity.ClassMethod = classUpdate.ClassMethod;
            classEntity.ClassLevel = classUpdate.ClassLevel;
            classEntity.ClassFee = classUpdate.ClassFee;
            classEntity.StudentId = classUpdate.StudentId;


            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<ClassViewModel>> GetAllClasses()
        {
            var classEntities = await _context.Classes
                .Include(c => c.Student)
                .Include(c => c.Tutor)
                .Include(c => c.Schedules)
                .ToListAsync();

            var classViewModels = classEntities.Select(c => c.Adapt<ClassViewModel>()).ToList();

            return classViewModels;
        }
    }

}
