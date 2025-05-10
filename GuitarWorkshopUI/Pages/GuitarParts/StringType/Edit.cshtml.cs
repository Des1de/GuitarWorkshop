using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.StringType
{
    public class EditModel : PageModel
    {
        private readonly IStringTypeService _stringTypeService;
        public EditModel(IStringTypeService stringTypeService)
        {
            _stringTypeService = stringTypeService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            StringType = (await _stringTypeService.GetAllStringTypes()).Single(x => x.StringId == id);
            return Page();
        }

        [BindProperty]
        public StringTypeDTO StringType { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _stringTypeService.UpdateStringType(StringType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
