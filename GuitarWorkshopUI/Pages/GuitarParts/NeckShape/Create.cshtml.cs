using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.NeckShape
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly INeckShapeService _neckShapeService;
        public CreateModel(INeckShapeService neckShapeService)
        {
            _neckShapeService = neckShapeService;
        }
        public IActionResult OnGet()
        {
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

            await _neckShapeService.CreateNeckShape(NeckShape);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
