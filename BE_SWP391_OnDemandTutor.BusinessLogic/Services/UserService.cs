
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
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
        public UserService(BE_SWP391_OnDemandTutorDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result.Select(user => new UserViewModel()
            {

                UserId = user.UserId,
                Username = user.Username,
                ProfileImage = user.ProfileImage,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                Fullname = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Role = user.Role,
                City = user.City,
                District = user.District,
                Ward = user.Ward,
                Street = user.Street,
                TutorType = user.TutorType,
                School = user.School,
                TutorDescription = user.TutorDescription,
                IsActive = user.IsActive,
            }).ToList();

        }

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserViewModel()
            {
                UserId = user.UserId,
                Username = user.Username,
                ProfileImage = user.ProfileImage,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth,
                Fullname = user.FullName,
                Gender = user.Gender,
                Role = user.Role,
                City = user.City,
                District = user.District,
                Ward = user.Ward,
                Street = user.Street,
                TutorType = user.TutorType,
                School = user.School,
                TutorDescription = user.TutorDescription,
                IsActive = user.IsActive,
            };
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

            var user = new User()
            {
                Username = request.Username,
                ProfileImage = request.ProfileImage,
                Password = passwordHash,
                FullName = request.Fullname,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Role = request.Role,
                City = request.City,
                District = request.District,
                Ward = request.Ward,
                Street = request.Street,
                TutorType = request.TutorType,
                School = request.School,
                TutorDescription = request.TutorDescription,
                IsActive = true,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserViewModel()
            {

                UserId = user.UserId,
                Username = user.Username,
                ProfileImage = user.ProfileImage,
                Fullname = user.FullName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Role = user.Role,
                City = user.City,
                District = user.District,
                Ward = user.Ward,
                Street = user.Street,
                TutorType = user.TutorType,
                School = user.School,
                TutorDescription = user.TutorDescription,
                IsActive = user.IsActive,
            };
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
            user.ProfileImage = request.ProfileImage;
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

            return new UserViewModel()
            {
                UserId = user.UserId,
                Username = user.Username,
                Fullname = user.FullName,
                ProfileImage = user.ProfileImage,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Role = user.Role,
                City = user.City,
                District = user.District,
                Ward = user.Ward,
                Street = user.Street,
                TutorType = user.TutorType,
                School = user.School,
                TutorDescription = user.TutorDescription,
                IsActive = user.IsActive,
            };
        }
    }

}
