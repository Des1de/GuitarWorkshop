using GuitarWorkshopUI.DTO.User;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IUserService
    {
        Task<LoginUserDTO?> LoginUser(string username, string password);
        Task<bool> RegisterUser(RegisterUserDTO newUser);
        Task<bool> RegisterManager(RegisterManagerDTO newUser);
        Task<bool> UserExistsByEmailAsync(string email);
        Task<bool> UserExistsByLoginAsync(string login);
        Task<List<GetUserDTO>> GetAllUsers();
        Task ChangeBlockStatus(int userId); 
    }
}
