using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckShape
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly INeckShapeService _neckShapeService;
        public EditModel(INeckShapeService neckShapeService)
        {
            _neckShapeService = neckShapeService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            NeckShape = (await _neckShapeService.GetAllNeckShapes()).Single(x => x.ShapeId == id);
            return Page();
        }

        [BindProperty]
        public NeckShapeDTO NeckShape { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _neckShapeService.UpdateNeckShape(NeckShape);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
