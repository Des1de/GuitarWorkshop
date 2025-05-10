using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuitarWorkshopUI.Pages.GuitarParts.WoodsType
{
    public class CreateModel : PageModel
    {
        private readonly IWoodsTypeService _woodsTypeService;
        public SelectList GuitarPartOptions = new(new List<string> { "BottomDeck", "Fingerboard", "Neck", "TopDeck" });
        public CreateModel(IWoodsTypeService woodsTypeService)
        {
            _woodsTypeService = woodsTypeService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WoodsTypeDTO WoodsType { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _woodsTypeService.CreateWoodsType(WoodsType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
