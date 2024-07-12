
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mapster;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OnDemandTutor.DataAccess.ExceptionModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;
using BE_SWP391_OnDemandTutor.Common.Paging;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IUserService
    {
        Task<string> Login(LoginRequestModel request);
        Task<UserViewModel> Register(RegisterRequestModel request);
        Task<UserViewModel> UpdateUser(int userId, UpdateUserRequestModel request);
        Task<List<UserViewModel>> GetAll(PagingSizeModel paging);
        Task<List<TutorViewModel>> GetAllTutors(PagingSizeModel paging);
        Task<TutorViewModel> GetTutorById(int userId);
        Task<(List<TutorViewModel>, int)> SearchTutors(SearchTutorQuery query);
        Task<UserViewModel> GetById(int id);
        Task<UserViewModel> UpdateUserProfileImage(int userId, string imageUrl);
        Task<UserViewModel> UpdateUserStatus(int userId);
        Task<UserViewModel> UpdateTutorProfile(int userId, UpdateTutorProfileRequestModel request);
        Task<UserViewModel> UpdateUserRole(int userId, string role);
        Task<UserViewModel> GetUserByEmail(string email);
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

        public async Task<List<UserViewModel>> GetAll(PagingSizeModel paging)
        {
            var result = await _context.Users.ToListAsync();

            return result.Skip((paging.Page - 1) * paging.Limit).Take(paging.Limit).Select(user => user.Adapt<UserViewModel>()).ToList();
        }
        public async Task<List<TutorViewModel>> GetAllTutors(PagingSizeModel paging)
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
                .Skip(paging.Page - 1).Take(paging.Limit)
                .Select(b => b.Adapt<TutorBookingViewModel>()).ToList();
             
                return u.Adapt<TutorViewModel>();
            }
            ).ToList();
            return tutorResult;
        }

        public async Task<(List<TutorViewModel>, int)> SearchTutors(SearchTutorQuery query)
        {
            var result =  _context.Users
                .Include(u => u.TutorClasses)
                .ThenInclude(c => c.Schedules)
                .ThenInclude(s => s.Bookings)
                .Include(u => u.TutorDegrees)
                .AsQueryable();
            result = result.Where(u => u.Role == "Tutor");
            if (!string.IsNullOrWhiteSpace(query.TutorName))
            {
                result = result.Where(u => u.FullName.Contains(query.TutorName));
            }
            if (!string.IsNullOrWhiteSpace(query.City))
            {
                result = result.Where(u => u.City.Contains(query.City));
            }
            if (!string.IsNullOrWhiteSpace(query.District))
            {
                result = result.Where(u => u.District.Contains(query.District));
            }
            if (!string.IsNullOrWhiteSpace(query.Ward))
            {
                result = result.Where(u => u.Ward.Contains(query.Ward));
            }
            if (!string.IsNullOrWhiteSpace(query.TutorType))
            {
                result = result.Where(u => u.TutorType.Contains(query.TutorType));
            }
            var totalCount = result.Count();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var tutorResult = await result.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            return (tutorResult.Select(u =>
            {
                var t = u.Adapt<TutorViewModel>();
                var classes = u.TutorClasses.Select(c => c.Adapt<TutorClassViewModel>()).ToList();
                var degrees = u.TutorDegrees.Select(d => d.Adapt<TutorDegreeViewModel>()).ToList();
                var bookings = u.TutorClasses
                .SelectMany(c => c.Schedules)
                .SelectMany(s => s.Bookings)
                .Select(b => b.Adapt<TutorBookingViewModel>()).ToList();
                t.Classes = classes;
                t.TutorDegrees = degrees;
                t.Bookings = bookings;
                return t;
            }
            ).ToList(), totalCount);
        }
        public async Task<TutorViewModel> GetTutorById(int userId)
        {
            var result = await _context.Users
                .Include(u => u.TutorClasses)
                .ThenInclude(c => c.Schedules)
                .ThenInclude(s => s.Bookings)
                .Include(u => u.TutorDegrees)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            if ( result.Role != "Tutor")
            {
                throw new NotFoundException($"No Tutor with ID {userId} founded");
            }

            var classes = result.TutorClasses.Select(c => c.Adapt<TutorClassViewModel>()).ToList();
            var degrees = result.TutorDegrees.Select(d => d.Adapt<TutorDegreeViewModel>()).ToList();
            var bookings = result.TutorClasses
            .SelectMany(c => c.Schedules)
            .SelectMany(s => s.Bookings)
            .Select(b => b.Adapt<TutorBookingViewModel>()).ToList();
            return result.Adapt<TutorViewModel>();
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new BadRequestException("User not found");
            }

            return user.Adapt<UserViewModel>();
        }
        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == email);
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


        public async Task<UserViewModel> UpdateUser(int userId, UpdateUserRequestModel request)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            var usernameAvailable = await _context.Users.AnyAsync(u => u.Username == request.Username && u.UserId != user.UserId);
            if (usernameAvailable)
            {
                throw new Exception("Username available.");
            }
            user.Username = request.Username;
            user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            user.DateOfBirth = request.DateOfBirth;
            user.Gender = request.Gender;
            user.City = request.City;
            user.District = request.District;
            user.Ward = request.Ward;
            user.Street = request.Street;

            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
        public async Task<UserViewModel> UpdateTutorProfile(int userId, UpdateTutorProfileRequestModel request)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            user.DateOfBirth = request.DateOfBirth;
            user.Gender = request.Gender;
            user.City = request.City;
            user.District = request.District;
            user.Ward = request.Ward;
            user.Street = request.Street;
            user.TutorType = request.TutorType;
            user.School = request.School;
            user.TutorDescription = request.TutorDescription;

            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
        public async Task<UserViewModel> UpdateUserProfileImage(int userId, string imageUrl)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            user.ProfileImage = imageUrl;
            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
        public async Task<UserViewModel> UpdateUserRole(int userId, string role)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            user.Role = role;
            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
        public async Task<UserViewModel> UpdateUserStatus(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new Exception("User does not exist");
            }
            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            return user.Adapt<UserViewModel>();
        }
    }

}
