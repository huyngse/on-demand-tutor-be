using AutoMapper;
using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        Task<ClassViewModel> GetDetail(int classId);
        Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate, int classID) ;
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
            var newClass = new Class
            {
                ClassName = classCreate.ClassName,
                ClassTime = classCreate.ClassTime,
                Active = classCreate.Active,
                ClassInfo = classCreate.ClassInfo,
                ClassRequire = classCreate.ClassRequire,
                ClassAddress = classCreate.ClassAddress,
                ClassMethod = classCreate.ClassMethod,
                ClassLevel = classCreate.ClassLevel,
                ClassFee = classCreate.ClassFee,
                TutorId = classCreate.TutorId,
                City = classCreate.City,
                District = classCreate.District,
                Ward = classCreate.Ward,
                CreatedDate = DateTime.UtcNow
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            var schedules = await _context.Schedules.Where(s => s.ClassID == newClass.ClassId)
                          .Select(x => x.Adapt<ScheduleViewModel>()).ToListAsync();

            return new ClassViewModel()
            {
                ClassName = newClass.ClassName,
                ClassTime = newClass.ClassTime,
                Active = newClass.Active,
                ClassInfo = newClass.ClassInfo,
                ClassRequire = newClass.ClassRequire,
                ClassAddress = newClass.ClassAddress,
                ClassMethod = newClass.ClassMethod,
                ClassLevel = newClass.ClassLevel,
                ClassFee = newClass.ClassFee,
                TutorId = newClass.TutorId,
                City = classCreate.City,
                CreatedDate = DateTime.UtcNow,
                Schedules = schedules
            };
                }

        public async Task<(bool Success, string ClassName)> DeactivateClass(int idTmp)
        {
            var classEntity = await _context.Classes.FindAsync(idTmp);
            if (classEntity == null)
            {
                return (false, null);
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
                return null;
            }

            return new ClassViewModel
            {
                ClassId = classEntity.ClassId,
                ClassName = classEntity.ClassName,
                ClassTime = classEntity.ClassTime,
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
                    Description =s.Description,
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
                return false;
            }
            if (classUpdate.StudentId.HasValue)
            {
                var studentExists = await _context.Users.AnyAsync(u => u.UserId == classUpdate.StudentId.Value);
                if (!studentExists)
                {
                    // You can return a custom error message or handle it differently
                    return false;
                }
            }

            classEntity.ClassName = classUpdate.ClassName;
            classEntity.ClassTime = classUpdate.ClassTime;
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
