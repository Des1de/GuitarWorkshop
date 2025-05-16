using GuitarWorkshopUI.DTO.GuitarParts;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts.TuningMachine
{
    [Authorize(Roles = "Admin")]
    public class GetAllModel : PageModel
    {
        private readonly ITuningMachineService _tuningMachineService;
        public IList<TuningMachineDTO> TuningMachines { get; set; } = default!;
        public GetAllModel(ITuningMachineService tuningMachineService)
        {
            _tuningMachineService = tuningMachineService;
        }

        public async Task OnGetAsync()
        {
            TuningMachines = await _tuningMachineService.GetAllTuningMachines();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            TuningMachines = await _tuningMachineService.GetAllTuningMachines();
            var finish = TuningMachines.Single(x => x.MachineId == id);

            await _tuningMachineService.DeletTuningMachine(finish);

            return RedirectToPage(); // Refresh the page
        }
    }
}
