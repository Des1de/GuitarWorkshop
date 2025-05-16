using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckScale
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly INeckScaleService _neckScaleService;
        public CreateModel(INeckScaleService neckScaleService)
        {
            _neckScaleService = neckScaleService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NeckScaleDTO NeckScale { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _neckScaleService.CreateNeckScale(NeckScale);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
