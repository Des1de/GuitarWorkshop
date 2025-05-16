using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.Finish
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IFinishesService _finishesService;
        public CreateModel(IFinishesService finishesService)
        {
            _finishesService = finishesService;
        }
        public IActionResult OnGet()
        {
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

            await _finishesService.CreateFinish(Finish);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
