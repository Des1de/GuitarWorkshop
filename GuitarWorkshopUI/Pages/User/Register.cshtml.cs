using GuitarWorkshopUI.DTO.User;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public RegisterUserDTO UserDTO { get; set; } = new();
        [TempData]
        public string? ErrorMessage { get; set; }

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UserDTO.Password != UserDTO.RepeatPassword)
            {
                ModelState.AddModelError("UserDTO.RepeatPassword", "Passwords do not match.");
                return Page();
            }

            if (await _userService.UserExistsByLoginAsync(UserDTO.Login))
            {
                ModelState.AddModelError("UserDTO.Login", "Login is already taken.");
                return Page();
            }

            if (await _userService.UserExistsByEmailAsync(UserDTO.Email))
            {
                ModelState.AddModelError("UserDTO.Email", "Email is already registered.");
                return Page();
            }

            var success = await _userService.RegisterUser(UserDTO);
            if (success)
            {
                return RedirectToPage("/User/Login");
            }

            ErrorMessage = "Registration failed. Please try again.";
            return Page();
        }
    }
}
