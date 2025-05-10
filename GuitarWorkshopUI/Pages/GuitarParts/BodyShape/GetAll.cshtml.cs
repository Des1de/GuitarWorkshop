using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Pages.GuitarParts.BodyShape
{
    public class GetAllModel : PageModel
    {
        private readonly IBodyShapeService _bodyShapeService;
        public IList<BodyShapeDTO> BodyShapes { get; set; } = default!;
        public GetAllModel(IBodyShapeService bodyShapeService)
        {
            _bodyShapeService = bodyShapeService;
        }

        public async Task OnGetAsync()
        {
            BodyShapes = await _bodyShapeService.GetAllBodyShape(); 
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            BodyShapes = await _bodyShapeService.GetAllBodyShape();
            var bodyShape = BodyShapes.Single(x => x.ShapeId == id);

            await _bodyShapeService.DeleteBodyShape(bodyShape);

            return RedirectToPage(); // Refresh the page
        }
    }
}
