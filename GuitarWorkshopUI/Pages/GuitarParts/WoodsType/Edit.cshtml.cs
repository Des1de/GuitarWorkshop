using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GuitarWorkshopUI.Pages.GuitarParts.WoodsType
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IWoodsTypeService _woodsTypeService;
        public SelectList GuitarPartOptions = new(new List<string> { "BottomDeck", "Fingerboard", "Neck", "TopDeck" });
        public EditModel(IWoodsTypeService woodsTypeService)
        {
            _woodsTypeService = woodsTypeService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            WoodsType = (await _woodsTypeService.GetAllWoodsTypes()).Single(x => x.TypeId == id);
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

            await _woodsTypeService.UpdateWoodsType(WoodsType);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
