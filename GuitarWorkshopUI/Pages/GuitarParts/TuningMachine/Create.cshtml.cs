using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.TuningMachine
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ITuningMachineService _tuningMachineService;
        public CreateModel(ITuningMachineService tuningMachineService)
        {
            _tuningMachineService = tuningMachineService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TuningMachineDTO TuningMachine { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _tuningMachineService.CreateTuningMachine(TuningMachine);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
