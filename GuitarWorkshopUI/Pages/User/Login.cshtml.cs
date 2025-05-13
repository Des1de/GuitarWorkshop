using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace GuitarWorkshopUI.Pages.User
{
    
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService) 
        { 
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            UserDTO? user = await _userService.LoginUser(username, password);
            if (user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim("UserId", user.UserId.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");

                await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/Index");
            }

            return Unauthorized();
        }
    }
}
