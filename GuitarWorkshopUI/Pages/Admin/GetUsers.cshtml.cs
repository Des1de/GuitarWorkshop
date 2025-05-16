using GuitarWorkshopUI.DTO.User;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class GetUsersModel : PageModel
    {
        private readonly IUserService _userService;

        public List<GetUserDTO> Users { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchLogin { get; set; } = string.Empty;

        public GetUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            var allUsers = await _userService.GetAllUsers();
            Users = string.IsNullOrWhiteSpace(SearchLogin)
                            ? allUsers
                            : allUsers.Where(u => u.Login.Contains(SearchLogin, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public async Task<IActionResult> OnPostToggleBlockAsync(int id)
        {
            await _userService.ChangeBlockStatus(id);
            return RedirectToPage(new { SearchLogin });
        }
    }
}
