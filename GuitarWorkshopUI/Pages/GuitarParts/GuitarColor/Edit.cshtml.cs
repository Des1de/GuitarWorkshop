using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.GuitarColor
{
    public class EditModel : PageModel
    {
        private readonly IGuitarColorService _guitarColorService;
        public EditModel(IGuitarColorService guitarColorService)
        {
            _guitarColorService = guitarColorService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            GuitarColor = (await _guitarColorService.GetAllGuitarColors()).Single(x => x.ColorId == id);
            return Page();
        }

        [BindProperty]
        public GuitarColorDTO GuitarColor { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _guitarColorService.UpdateGuitarColor(GuitarColor);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
