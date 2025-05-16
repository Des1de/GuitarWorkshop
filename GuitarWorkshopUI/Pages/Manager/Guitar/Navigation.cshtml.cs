using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Manager.Guitar
{
    [Authorize(Roles = "Manager")]
    public class NavigationModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
