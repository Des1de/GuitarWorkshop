using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.Finish
{
    public class EditModel : PageModel
    {
        private readonly IFinishesService _finishesService;
        public EditModel(IFinishesService finishesService)
        {
            _finishesService = finishesService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Finish = (await _finishesService.GetAllFinishes()).Single(x => x.FinishId == id);
            return Page();
        }

        [BindProperty]
        public FinishDTO Finish { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _finishesService.UpdateFinish(Finish);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
