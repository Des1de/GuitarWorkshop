using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO.User
{
    public class LoginUserDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
    }
}
