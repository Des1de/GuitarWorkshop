using GuitarWorkshopUI.DTO.User;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GuitarWorkshopUI.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _contextFactory; 
        public UserService(IDbContextFactory<GuitarWorkshopContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task ChangeBlockStatus(int userId)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            await context.Users.Where(x => x.UserId == userId).ExecuteUpdateAsync(x => x.SetProperty(a => a.IsBlocked, a => !a.IsBlocked));
        }

        public async Task<List<GetUserDTO>> GetAllUsers()
        {
            var context = await _contextFactory.CreateDbContextAsync(); 
            var users = await context.Users.Select(x => new GetUserDTO
            {
                UserId = x.UserId,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                IsBlocked = x.IsBlocked,
                Login = x.Login,
            }).ToListAsync();

            return users; 
        }

        public async Task<LoginUserDTO?> LoginUser(string login, string password)
        {
            string passwordHash = HashPassowrd(password);
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.Users.Include(x => x.Role).Where(u => u.Login == login && u.PasswordHash == passwordHash).FirstOrDefaultAsync();

            if (user is not null)
            {
                return new LoginUserDTO
                {
                    UserId = user.UserId,
                    Login = login,
                    Role = user.Role.RoleName,
                };
            }

            return null; 
        }

        public async Task<bool> RegisterManager(RegisterManagerDTO newUser)
        {
            string passwordHash = HashPassowrd(newUser.Password);
            using var context = await _contextFactory.CreateDbContextAsync();
            if (!context.Users.Any(u => u.Login == newUser.Login))
            {
                var role = context.Roles.First(x => x.RoleName == "Manager");
                context.Users.Add(
                new User
                {
                    Login = newUser.Login,
                    PasswordHash = passwordHash,
                    DeliveryAddress = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    IsBlocked = false,
                    RoleId = role.RoleId
                });
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RegisterUser(RegisterUserDTO newUser)
        {
            string passwordHash = HashPassowrd(newUser.Password);
            using var context = await _contextFactory.CreateDbContextAsync();
            if (!context.Users.Any(u => u.Login == newUser.Login))
            {
                Role role; 
                if(context.Users.Include(x => x.Role).Any(x => x.Role.RoleName == "Admin"))
                    role = context.Roles.First(x => x.RoleName == "User");
                else 
                    role = context.Roles.First(x => x.RoleName == "Admin");
                context.Users.Add(
                new User
                {
                    Login = newUser.Login,
                    PasswordHash = passwordHash,
                    DeliveryAddress = newUser.DeliveryAddress,
                    Email = newUser.Email,
                    PhoneNumber = newUser.PhoneNumber,
                    IsBlocked = false,
                    RoleId = role.RoleId
                });
                await context.SaveChangesAsync();
                return true;
            }
           
            return false;
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            return context.Users.Where(x => x.Email == email).Any();
        }

        public async Task<bool> UserExistsByLoginAsync(string login)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            return context.Users.Where(x => x.Login == login).Any();
        }

        private string HashPassowrd(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
