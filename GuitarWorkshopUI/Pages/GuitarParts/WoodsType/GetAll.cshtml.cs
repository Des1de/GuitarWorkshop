using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.WoodsType
{
    [Authorize(Roles = "Admin")]
    public class GetAllModel : PageModel
    {
        private readonly IWoodsTypeService _woodsTypeService;
        public IList<WoodsTypeDTO> WoodsTypes { get; set; } = default!;
        public GetAllModel(IWoodsTypeService woodsTypeService)
        {
            _woodsTypeService = woodsTypeService;
        }

        public async Task OnGetAsync()
        {
            WoodsTypes = (await _woodsTypeService.GetAllWoodsTypes()).OrderBy(x => x.PartType).ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            WoodsTypes = (await _woodsTypeService.GetAllWoodsTypes()).OrderBy(x => x.PartType).ToList();
            var finish = WoodsTypes.Single(x => x.TypeId == id);

            await _woodsTypeService.DeletWoodsType(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
