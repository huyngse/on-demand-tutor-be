
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mapster;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using OnDemandTutor.DataAccess.ExceptionModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IUserService
    {
        Task<string> Login(LoginRequestModel request);
        Task<UserViewModel> Register(RegisterRequestModel request);
        Task<UserViewModel> UpdateUser(UpdateUserRequestModel request);
        Task<List<UserViewModel>> GetAll();
        Task<List<TutorViewModel>> GetAllTutors();
        //Task<List<TutorViewModel>> GetSearchTutors(SearchTutorQuery query);
        Task<UserViewModel> GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(BE_SWP391_OnDemandTutorDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var result = await _context.Users.ToListAsync();

            return result.Select(user => user.Adapt<UserViewModel>()).ToList();
        }
        public async Task<List<TutorViewModel>> GetAllTutors()
        {
            var result = await _context.Users
                .Include(u => u.TutorClasses)
                .ThenInclude(c => c.Schedules)
                .ThenInclude(s => s.Bookings)
                .Include(u => u.TutorDegrees)
                .ToListAsync();
            result = result.Where(u => u.Role == "Tutor").ToList();
            var tutorResult = result.Select(u =>
            {
                var classes = u.TutorClasses.Select(c => c.Adapt<TutorClassViewModel>()).ToList();
                var degrees = u.TutorDegrees.Select(d => d.Adapt<TutorDegreeViewModel>()).ToList();
                var bookings = u.TutorClasses
                .SelectMany(c => c.Schedules)
                .SelectMany(s => s.Bookings)
                .Select(b => new TutorBookingViewModel
                {
                    Address = b.Address,
                    BookingId = b.BookingId,
                    ClassFee = b.Schedule.Class.ClassFee,
                    CreateDate = b.CreateDate,
                    Description = b.Description,
                    EndDate = b.EndDate,
                    ScheduleId = b.ScheduleId,
                    StartDate = b.StartDate,
                    Status = b.Status
                }).ToList();
                return new TutorViewModel
                {
                    City = u.City,
                    DateOfBirth = u.DateOfBirth,
                    District = u.District,
                    FullName = u.FullName,
                    EmailAddress = u.EmailAddress,
                    Gender = u.Gender,
                    IsActive = u.IsActive,
                    PhoneNumber = u.PhoneNumber,
                    ProfileImage = u.ProfileImage,
                    School = u.School,
                    Street = u.Street,
                    Role = u.Role,
                    UserId = u.UserId,
                    TutorDescription = u.TutorDescription,
                    Username = u.Username,
                    TutorType = u.TutorType,
                    Ward = u.Ward,
                    Bookings = bookings,
                    Classes = classes,
                    TutorDegrees = degrees
                };
            }
            ).ToList();
            return tutorResult;
        }
        //public async Task<List<TutorViewModel>> GetSearchTutors(SearchTutorQuery query)
        //{
        //    var result = await _context.Users.ToListAsync();
        //    result = result.Where(u => u.Role == "Tutor").ToList();

        //    return result.Select(user => user.Adapt<UserViewModel>()).ToList();
        //}

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new BadRequestException("User not found");
            }

            return user.Adapt<UserViewModel>();
        }

        public async Task<string> Login(LoginRequestModel request)
        {
            var user = await _context.Users.Where(u => u.Username == request.UserName).FirstOrDefaultAsync();

            string passwordToCheck = request.Password;
            bool passwordVerified = false;
            string storedPassword = user.Password;


            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            if (storedPassword.Length == 60 && storedPassword.StartsWith("$2a$"))
            {
                // Mật khẩu đã được mã hóa, sử dụng Verify của BCrypt để xác minh
                passwordVerified = BCrypt.Net.BCrypt.Verify(passwordToCheck, storedPassword);
            } else
            {
                // Mật khẩu chưa được mã hóa, mã hóa mật khẩu trước khi xác minh
                passwordVerified = (passwordToCheck == storedPassword);
            }
            if (!passwordVerified)
            {
                throw new Exception("Wrong password");
            }

            var userClaims = new[]
            {
                new Claim("id", user.UserId.ToString()),
                new Claim("username", user.Username),
                new Claim("fullname", user.FullName),
                new Claim("phonenumber", user.PhoneNumber),
                new Claim("email", user.EmailAddress),
                new Claim("dateofbirth", user.DateOfBirth.ToString()),
                new Claim("gender", user.Gender),
                new Claim("role", user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Issuer"],
                    claims: userClaims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserViewModel> Register(RegisterRequestModel request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var existedUser = await _context.Users.Where(u => u.Username == request.Username).FirstOrDefaultAsync();
            var existedEm = await _context.Users.Where(u => u.EmailAddress == request.EmailAddress).FirstOrDefaultAsync();
            if (existedUser != null || existedEm != null)
            {
                throw new Exception("Username and EmailAddress already exists");
            }


            var user = request.Adapt<User>();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


            return user.Adapt<UserViewModel>();
        }


        public async Task<UserViewModel> UpdateUser(UpdateUserRequestModel request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var usernameAvailable = await _context.Users.AnyAsync(u => u.Username == request.Username && u.UserId != user.UserId);
            if (usernameAvailable)
            {
                throw new Exception("Username available.");
            }

            var emailAvailable = await _context.Users.AnyAsync(u => u.EmailAddress == request.EmailAddress && u.UserId != user.UserId);
            if (emailAvailable)
            {
                throw new Exception("Email available.");
            }

            user.Username = request.Username;
            user.Password = passwordHash;
            user.FullName = request.Fullname;
            user.PhoneNumber = request.PhoneNumber;
            user.EmailAddress = request.EmailAddress;
            user.DateOfBirth = request.DateOfBirth;
            user.Gender = request.Gender;
            user.Role = request.Role;
            user.City = request.City;
            user.District = request.District;
            user.Ward = request.Ward;
            user.Street = request.Street;
            user.TutorType = request.TutorType;
            user.School = request.School;
            user.TutorDescription = request.TutorDescription;
            user.IsActive = request.IsActive;

            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
    }

}
