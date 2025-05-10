using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.FretNumber
{
    public class GetAllModel : PageModel
    {
        private readonly IFretNumberTypeService _fretNumberTypeService;
        public IList<FretNumberTypeDTO> FretNumberTypes { get; set; } = default!;
        public GetAllModel(IFretNumberTypeService fretNumberTypeService)
        {
            _fretNumberTypeService = fretNumberTypeService;
        }

        public async Task OnGetAsync()
        {
            FretNumberTypes = await _fretNumberTypeService.GetAllFretNumberTypes();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            FretNumberTypes = await _fretNumberTypeService.GetAllFretNumberTypes();
            var finish = FretNumberTypes.Single(x => x.TypeId == id);

            await _fretNumberTypeService.DeleteFretNumberType(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
