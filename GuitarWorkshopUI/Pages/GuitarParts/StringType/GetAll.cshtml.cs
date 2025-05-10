using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.StringType
{
    public class GetAllModel : PageModel
    {
        private readonly IStringTypeService _stringTypeService;
        public IList<StringTypeDTO> StringTypes { get; set; } = default!;
        public GetAllModel(IStringTypeService stringTypeService)
        {
            _stringTypeService = stringTypeService;
        }

        public async Task OnGetAsync()
        {
            StringTypes = await _stringTypeService.GetAllStringTypes();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            StringTypes = await _stringTypeService.GetAllStringTypes();
            var finish = StringTypes.Single(x => x.StringId == id);

            await _stringTypeService.DeletStringType(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
