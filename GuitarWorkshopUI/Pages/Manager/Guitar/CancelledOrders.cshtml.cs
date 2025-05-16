using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Pages.Manager.Guitar
{
    [Authorize(Roles = "Manager")]
    public class CancelledOrdersModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;

        public CancelledOrdersModel(IGuitarOrderService guitarOrderService)
        {
            _guitarOrderService = guitarOrderService;
        }
        public List<GuitarOrderDTO> CancelledOrders { get; set; } = new();

        public async Task OnGetAsync()
        {
            CancelledOrders = await _guitarOrderService.GetAllDoneOrders();
        }
    }
}
