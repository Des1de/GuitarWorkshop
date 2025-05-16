using GuitarWorkshopUI.DTO.User;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class RegisterManagerModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterManagerModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public RegisterManagerDTO NewManager { get; set; } = new();

        [TempData]
        public string? ErrorMessage { get; set; }

        [TempData]
        public string? SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (NewManager.Password != NewManager.RepeatPassword)
            {
                ModelState.AddModelError("NewManager.RepeatPassword", "Passwords do not match.");
                return Page();
            }

            if (await _userService.UserExistsByLoginAsync(NewManager.Login))
            {
                ModelState.AddModelError("NewManager.Login", "Login is already taken.");
                return Page();
            }

            var success = await _userService.RegisterManager(NewManager);

            if (success)
            {
                SuccessMessage = "Manager successfully registered.";
                ModelState.Clear();
                NewManager = new RegisterManagerDTO();
                return RedirectToPage(); 
            }

            ErrorMessage = "Failed to register manager. Please try again.";
            return Page();
        }
    }
}
