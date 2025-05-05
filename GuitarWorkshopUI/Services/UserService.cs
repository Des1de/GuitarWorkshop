using GuitarWorkshopUI.DTO;
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

        public async Task<UserDTO?> LoginUser(string login, string password)
        {
            string passwordHash = HashPassowrd(password);
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.Users.Where(u => u.Login == login && u.PasswordHash == passwordHash).FirstOrDefaultAsync();

            if (user is not null)
            {
                return new UserDTO
                {
                    Login = login
                };
            }

            return null; 
        }

        public async Task<bool> RegisterUser(UserDTO newUser)
        {
            string passwordHash = HashPassowrd(newUser.Password);
            using var context = await _contextFactory.CreateDbContextAsync();
            if (!context.Users.Any(u => u.Login == newUser.Login))
            {
                context.Users.Add(
                new User
                {
                    Login = newUser.Login,
                    PasswordHash = passwordHash
                });
                await context.SaveChangesAsync();
                return true;
            }
           
            return false;
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
