using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.FretNumber
{
    public class CreateModel : PageModel
    {
        private readonly IFretNumberTypeService _fretNumberTypeService;
        public CreateModel(IFretNumberTypeService fretNumberTypeService)
        {
            _fretNumberTypeService = fretNumberTypeService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FretNumberTypeDTO FretNumberType { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _fretNumberTypeService.CreateFretNumberType(FretNumberType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
