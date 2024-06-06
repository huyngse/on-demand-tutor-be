using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Dynamic.Core;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        Task<ClassViewModel> GetDetail(int classId);
        Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate);
        Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate, int userId);
        Task<ClassViewModel> GetById(int idTmp);
        Task<(bool Success, string ClassName)> DeactivateClass(int idTmp);
    }

    public class ClassService : IClassService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IConfiguration _configuration;
        public ClassService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
        }

        public async Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate, int userid)
        {
            var newClass = new Class
            {
                ClassName = classCreate.ClassName,
                ClassTime = classCreate.ClassTime,
                ClassInfo = classCreate.ClassInfo,
                ClassRequire = classCreate.ClassRequire,
                ClassAddress = classCreate.ClassAddress,
                ClassMethod = classCreate.ClassMethod,
                ClassLevel = classCreate.ClassLevel,
                ClassFee = classCreate.ClassFee,
                StudentId = classCreate.StudentId,
                TutorId = classCreate.TutorId,
                ScheduleId = classCreate.ScheduleId,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };
            _context.Classes.AddAsync(newClass);
            await _context.SaveChangesAsync();

            return new ClassViewModel
            {
                ClassName = newClass.ClassName,
                ClassTime = newClass.ClassTime,
                ClassInfo = newClass.ClassInfo,
                ClassRequire = newClass.ClassRequire,
                ClassAddress = newClass.ClassAddress,
                ClassMethod = newClass.ClassMethod,
                ClassLevel = newClass.ClassLevel,
                ClassFee = newClass.ClassFee,
                StudentId = newClass.StudentId,
                TutorId = newClass.TutorId,
                ScheduleId = newClass.ScheduleId
            };

        }
        public async Task<(bool Success, string ClassName)> DeactivateClass(int idTmp)
        {
            var classEntity = await _context.Classes.FindAsync(idTmp);
            if (classEntity == null)
            {
                return (false, null);
            }

            classEntity.IsActive = false;
            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();

            return (true, classEntity.ClassName);
        }

        public async Task<ClassViewModel> GetById(int idTmp)
        {
            var classEntity = await _context.Classes
               .FirstOrDefaultAsync(c => c.ClassId == idTmp);

            if (classEntity == null)
            {
                return null;
            }

            return new ClassViewModel
            {
                ClassName = classEntity.ClassName,
                ClassTime = classEntity.ClassTime,
                ClassInfo = classEntity.ClassInfo,
                ClassRequire = classEntity.ClassRequire,
                ClassAddress = classEntity.ClassAddress,
                ClassMethod = classEntity.ClassMethod,
                ClassLevel = classEntity.ClassLevel,
                ClassFee = classEntity.ClassFee,
                StudentId = classEntity.StudentId,
                TutorId = classEntity.TutorId,
                ScheduleId = classEntity.ScheduleId
            };
        }

        public async Task<ClassViewModel> GetDetail(int classId)
        {
            var classEntity = await _context.Classes
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
                StudentId = classEntity.StudentId,
                TutorId = classEntity.TutorId,
                ScheduleId = classEntity.ScheduleId
            };
        }

        public async Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate)
        {
            var classEntity = await _context.Classes.FindAsync(classUpdate.ClassId);
            if (classEntity == null)
            {
                return false;
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
            classEntity.TutorId = classUpdate.TutorId;
            classEntity.ScheduleId = classUpdate.ScheduleId;

            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
