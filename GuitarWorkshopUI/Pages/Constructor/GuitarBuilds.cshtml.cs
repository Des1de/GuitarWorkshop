using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Constructor
{
    [Authorize(Roles = "User")]
    public class GuitarBuildsModel : PageModel
    {
        private readonly IGuitarBuildService _guitarBuildService;
        public GuitarBuildsModel(IGuitarBuildService guitarBuildService)
        {
            _guitarBuildService = guitarBuildService;
        }
        [BindProperty]
        public List<GuitarBuildDTO> GuitarBuilds { get; set; }

        public async Task OnGetAsync()
        {
            string userId = User.FindFirst("UserId")?.Value;
            if (int.TryParse(userId, out int id))
            {
                GuitarBuilds = await _guitarBuildService.GetGuitarBuildsByUserId(id);
            }
            
        }

        public IActionResult OnPostOrder(int id)
        {
            return RedirectToPage("/Order/CreateGuitarOrder", new { buildId = id }); 
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var guitarBuild = await _guitarBuildService.GetGuitarBuild(id);
            await _guitarBuildService.DeleteGuitarBuild(guitarBuild);
            return RedirectToPage(); 
        }
    }
}
