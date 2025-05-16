using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.Finish
{
    [Authorize(Roles = "Admin")]
    public class GetAllModel : PageModel
    {
        private readonly IFinishesService _finishesService;
        public IList<FinishDTO> Finishes { get; set; } = default!;
        public GetAllModel(IFinishesService finishesService)
        {
            _finishesService = finishesService;
        }

        public async Task OnGetAsync()
        {
            Finishes = await _finishesService.GetAllFinishes();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Finishes = await _finishesService.GetAllFinishes();
            var finish = Finishes.Single(x => x.FinishId == id);

            await _finishesService.DeleteFinish(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
