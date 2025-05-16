using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckShape
{
    [Authorize(Roles = "Admin")]
    public class GetAllModel : PageModel
    {
        private readonly INeckShapeService _neckShapeService;
        public IList<NeckShapeDTO> NeckShapes { get; set; } = default!;
        public GetAllModel(INeckShapeService neckShapeService)
        {
            _neckShapeService = neckShapeService;
        }

        public async Task OnGetAsync()
        {
            NeckShapes = await _neckShapeService.GetAllNeckShapes();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            NeckShapes = await _neckShapeService.GetAllNeckShapes();
            var finish = NeckShapes.Single(x => x.ShapeId == id);

            await _neckShapeService.DeletNeckShape(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
