using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Constructor
{
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
            // TODO: Add logic to place an order
            // Example: OrderService.PlaceOrder(id);
            return RedirectToPage(); // Refresh page
        }

        public IActionResult OnPostDelete(int id)
        {
            // TODO: Add logic to delete a build
            // Example: GuitarBuildService.DeleteBuild(id);
            return RedirectToPage(); // Refresh page
        }
    }
}
