using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO.User
{
    public class GetUserDTO
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
    }
}
