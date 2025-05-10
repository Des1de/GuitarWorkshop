using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.HeadstockStyle
{
    public class GetAllModel : PageModel
    {
        private readonly IHeadstockStyleService _headstockStyleService;
        public IList<HeadstockStyleDTO> HeadstockStyles { get; set; } = default!;
        public GetAllModel(IHeadstockStyleService headstockStyleService)
        {
            _headstockStyleService = headstockStyleService;
        }

        public async Task OnGetAsync()
        {
            HeadstockStyles = await _headstockStyleService.GetAllHeadstockStyles();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            HeadstockStyles = await _headstockStyleService.GetAllHeadstockStyles();
            var finish = HeadstockStyles.Single(x => x.StyleId == id);

            await _headstockStyleService.DeleteHeadstockStyle(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
