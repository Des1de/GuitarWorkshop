using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckScale
{
    public class EditModel : PageModel
    {
        private readonly INeckScaleService _neckScaleService;
        public EditModel(INeckScaleService neckScaleService)
        {
            _neckScaleService = neckScaleService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            NeckScale = (await _neckScaleService.GetAllNeckScales()).Single(x => x.ScaleId == id);
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

            await _neckScaleService.UpdateNeckScale(NeckScale);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
