using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.HeadstockStyle
{
    public class EditModel : PageModel
    {
        private readonly IHeadstockStyleService _headstockStyleService;
        public EditModel(IHeadstockStyleService headstockStyleService)
        {
            _headstockStyleService = headstockStyleService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            HeadstockStyle = (await _headstockStyleService.GetAllHeadstockStyles()).Single(x => x.StyleId == id);
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

            await _headstockStyleService.UpdateHeadstockStyle(HeadstockStyle);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
