using System.ComponentModel.DataAnnotations;

namespace GuitarWorkshopUI.DTO.User
{
    public class RegisterManagerDTO
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Login is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Login must be between 4 and 20 characters.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please repeat the password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
        
    }
}
