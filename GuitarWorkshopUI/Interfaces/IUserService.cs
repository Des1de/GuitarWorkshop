using GuitarWorkshopUI.DTO;
using System.Security.Claims;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO?> LoginUser(string username, string password);
        Task<bool> RegisterUser(UserDTO newUser);
    }
}
