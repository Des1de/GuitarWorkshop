using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckScale
{
    public class GetAllModel : PageModel
    {
        private readonly INeckScaleService _neckScaleService;
        public IList<NeckScaleDTO> NeckScales { get; set; } = default!;
        public GetAllModel(INeckScaleService neckScaleService)
        {
            _neckScaleService = neckScaleService;
        }

        public async Task OnGetAsync()
        {
            NeckScales = await _neckScaleService.GetAllNeckScales();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            NeckScales = await _neckScaleService.GetAllNeckScales();
            var finish = NeckScales.Single(x => x.ScaleId == id);

            await _neckScaleService.DeletNeckScale(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
