using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.HeadstockStyle
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IHeadstockStyleService _headstockStyleService;
        public CreateModel(IHeadstockStyleService headstockStyleService)
        {
            _headstockStyleService = headstockStyleService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HeadstockStyleDTO HeadstockStyle { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _headstockStyleService.CreateHeadstockStyle(HeadstockStyle);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
