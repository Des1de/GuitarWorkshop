using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.GuitarColor
{
    public class CreateModel : PageModel
    {
        private readonly IGuitarColorService _guitarColorService;
        public CreateModel(IGuitarColorService guitarColorService)
        {
            _guitarColorService = guitarColorService;
        }
        public IActionResult OnGet()
        {
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

            await _guitarColorService.CreateGuitarColor(GuitarColor);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
