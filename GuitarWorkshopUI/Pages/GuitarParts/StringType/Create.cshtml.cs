using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.StringType
{
    public class CreateModel : PageModel
    {
        private readonly IStringTypeService _stringTypeService;
        public CreateModel(IStringTypeService stringTypeService)
        {
            _stringTypeService = stringTypeService;
        }
        public IActionResult OnGet()
        {
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

            await _stringTypeService.CreateStringType(StringType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
