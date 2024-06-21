
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

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IUserService
    {
        Task<string> Login(LoginRequestModel request);
        Task<UserViewModel> Register(RegisterRequestModel request);
        Task<UserViewModel> UpdateUser(UpdateUserRequestModel request);
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IFirebaseService _firebaseService;
        public UserService(BE_SWP391_OnDemandTutorDbContext context, IConfiguration configuration, IFirebaseService firebaseService)
        {
            _context = context;
            _configuration = configuration;
            _firebaseService = firebaseService;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
          
            return result.Select(user => user.Adapt<UserViewModel>()).ToList();
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

        public async Task<string> Login(LoginRequestModel request)
        {
            var user = await _context.Users.Where(u => u.Username == request.UserName ).FirstOrDefaultAsync();

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
            }
            else
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
            user.ProfileImage = await _firebaseService.UploadUserImage(request.ProfileImage);
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
            user.ProfileImage = await _firebaseService.UploadUserImage(request.ProfileImage);
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
