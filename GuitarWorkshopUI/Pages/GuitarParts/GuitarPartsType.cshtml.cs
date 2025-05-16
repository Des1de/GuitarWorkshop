using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.GuitarParts
{
    [Authorize(Roles = "Admin")]
    public class GuitarPartsTypeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
