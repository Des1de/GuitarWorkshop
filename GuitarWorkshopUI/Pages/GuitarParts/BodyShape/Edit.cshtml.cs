using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.BodyShape
{
    public class EditModel : PageModel
    {
        private readonly IBodyShapeService _bodyShapeService;
        public EditModel(IBodyShapeService bodyShapeService)
        {
            _bodyShapeService = bodyShapeService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            BodyShape = (await _bodyShapeService.GetAllBodyShape()).Single(x => x.ShapeId == id); 
            return Page();
        }

        [BindProperty]
        public BodyShapeDTO BodyShape { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bodyShapeService.UpdateBodyShape(BodyShape);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
