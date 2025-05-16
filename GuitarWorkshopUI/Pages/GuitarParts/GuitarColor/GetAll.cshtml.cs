using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.GuitarColor
{
    [Authorize(Roles = "Admin")]
    public class GetAllModel : PageModel
    {
        private readonly IGuitarColorService _guitarColorService;
        public IList<GuitarColorDTO> GuitarColors { get; set; } = default!;
        public GetAllModel(IGuitarColorService guitarColorService)
        {
            _guitarColorService = guitarColorService;
        }

        public async Task OnGetAsync()
        {
            GuitarColors = await _guitarColorService.GetAllGuitarColors();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            GuitarColors = await _guitarColorService.GetAllGuitarColors();
            var guitarColor = GuitarColors.Single(x => x.ColorId == id);

            await _guitarColorService.DeleteGuitarColor(guitarColor);

            return RedirectToPage(); // Refresh the page
        }
    }
}
