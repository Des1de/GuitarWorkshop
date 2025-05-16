using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.FretNumber
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IFretNumberTypeService _fretNumberTypeService;
        public EditModel(IFretNumberTypeService fretNumberTypeService)
        {
            _fretNumberTypeService = fretNumberTypeService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            FretNumberType = (await _fretNumberTypeService.GetAllFretNumberTypes()).Single(x => x.TypeId == id);
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

            await _fretNumberTypeService.UpdateFretNumberType(FretNumberType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
