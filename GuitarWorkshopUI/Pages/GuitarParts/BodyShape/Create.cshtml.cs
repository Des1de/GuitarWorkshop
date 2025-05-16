using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Pages.GuitarParts.BodyShape
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IBodyShapeService _bodyShapeService;
        public CreateModel(IBodyShapeService bodyShapeService)
        {
            _bodyShapeService = bodyShapeService;
        }
        public IActionResult OnGet()
        {
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

            await _bodyShapeService.CreateBodyShape(BodyShape);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
