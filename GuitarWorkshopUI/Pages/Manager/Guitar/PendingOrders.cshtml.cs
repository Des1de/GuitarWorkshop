using GuitarWorkshopUI.Constants;
using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Manager.Guitar
{
    [Authorize(Roles = "Manager")]
    public class PendingOrdersModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;

        public PendingOrdersModel(IGuitarOrderService guitarOrderService)
        {
            _guitarOrderService = guitarOrderService;
        }

        public List<GuitarOrderDTO> PendingOrders { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            PendingOrders = await _guitarOrderService.GetAllPendingOrders(); 

            return Page();
        }

        public async Task<IActionResult> OnPostApproveAsync(int id)
        {
            var order = await _guitarOrderService.GetGuitarOrder(id);
            if (order == null || order.OrderStatus != OrderStatuses.Pending)
                return NotFound();

            await _guitarOrderService.SetOrderStatus(id, OrderStatuses.Approved);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            var order = await _guitarOrderService.GetGuitarOrder(id);
            if (order == null || order.OrderStatus != OrderStatuses.Pending)
                return NotFound();

            await _guitarOrderService.SetOrderStatus(id, OrderStatuses.Cancelled);

            return RedirectToPage();
        }
    }
}
