using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.TuningMachine
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ITuningMachineService _tuningMachineService;
        public EditModel(ITuningMachineService tuningMachineService)
        {
            _tuningMachineService = tuningMachineService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            TuningMachine = (await _tuningMachineService.GetAllTuningMachines()).Single(x => x.MachineId == id);
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

            await _tuningMachineService.UpdateTuningMachine(TuningMachine);

            return RedirectToPage("./GetAll"); // Redirect to the list page
        }
    }
}
