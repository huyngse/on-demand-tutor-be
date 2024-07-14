using AutoMapper;
using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using OnDemandTutor.DataAccess.ExceptionModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Class;
using BE_SWP391_OnDemandTutor.Common.Paging;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        Task<ClassViewModel> GetDetail(int classId);
        Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate, int classID);
        Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate);
        Task<ClassViewModel> GetById(int idTmp);
        Task<(bool Success, string ClassName)> DeactivateClass(int idTmp);
        Task<List<ClassViewModel>> GetAllClasses(PagingSizeModel paging);
        Task<List<TutorDetailClassViewModel>> GetClassByTutorId(int userId);
    }

    public class ClassService : IClassService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
       

        public ClassService(BE_SWP391_OnDemandTutorDbContext context, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }

        public async Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate)
        {
            var classEntity = classCreate.Adapt<Class>();
            _context.Classes.Add(classEntity);
            var rs = classEntity.Adapt<ClassViewModel>();
            var tutor =  await _userService.GetById(classEntity.TutorId);
            if( tutor is not null)
            {
                rs.Tutor = tutor.Adapt<TutorViewModel>();
            }
           
            await _context.SaveChangesAsync();

            return rs;
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
            classViewModel.Tutor = tutor.Adapt<TutorViewModel>();
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
            return classEntity.Adapt<ClassViewModel>();
        }

        public async Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate, int classID)
        {
            var classEntity = await _context.Classes.FindAsync(classID);
            if (classEntity == null)
            {
                throw new NotFoundException("Can not find the Class");
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
        public async Task<List<ClassViewModel>> GetAllClasses(PagingSizeModel paging)
        {
            var classEntities = await _context.Classes
                .Include(c => c.Student)
                .Include(c => c.Tutor)
                .Include(c => c.Schedules)
                .ToListAsync();

            var classViewModels = classEntities.Skip((paging.Page - 1) * paging.Limit).Take(paging.Limit).Select(c => c.Adapt<ClassViewModel>()).ToList();

            return classViewModels;
        }
        public async Task<List<TutorDetailClassViewModel>> GetClassByTutorId(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null || user.Role != "Tutor")
            {
                throw new NotFoundException($"No Tutor with ID {userId} founded");
            }
            var classEntities = await _context.Classes
                .Include(c => c.Student)
                .Include(c => c.Tutor)
                .Include(c => c.Schedules)
                .Where(b => b.TutorId == userId)
                .ToListAsync();
            var classViewModels = classEntities.Select(c => new TutorDetailClassViewModel
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                ClassInfo = c.ClassInfo,
                ClassRequire = c.ClassRequire,
                ClassAddress = c.ClassAddress,
                ClassMethod = c.ClassMethod,
                ClassLevel = c.ClassLevel,
                ClassFee = c.ClassFee,
                Schedules = c.Schedules?.Select(s => new ScheduleViewModel
                {
                    ScheduleID = s.ScheduleID,
                    Description = s.Description,
                    Title = s.Title,
                    DateOfWeek = s.DateOfWeek,
                    StartTime = s.StartTime.Value,
                    EndTime = s.EndTime.Value
                }).ToList() ?? new List<ScheduleViewModel>(), // Handle null Schedules
                CreatedDate = c.CreatedDate,
                Active = c.Active,
                District = c.District,
                Ward = c.Ward,
                City = c.City,
            }
            ).ToList();

            return classViewModels;
        }
    }

}
