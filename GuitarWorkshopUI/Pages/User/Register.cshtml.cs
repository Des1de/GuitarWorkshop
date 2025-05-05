using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace GuitarWorkshopUI.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public UserDTO UserDTO { get; set; } = new(); 
        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (await _userService.RegisterUser(UserDTO))
            {
                return RedirectToPage("/User/Login");
            }

            return RedirectToPage("/User/Register");
        }
    }
}
