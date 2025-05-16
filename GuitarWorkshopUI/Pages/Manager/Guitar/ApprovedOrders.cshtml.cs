using GuitarWorkshopUI.Constants;
using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Manager.Guitar
{
    [Authorize(Roles = "Manager")]
    public class ApprovedOrdersModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;

        public ApprovedOrdersModel(IGuitarOrderService guitarOrderService)
        {
            _guitarOrderService = guitarOrderService;
        }

        public List<GuitarOrderDTO> ApprovedOrders { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            ApprovedOrders = await _guitarOrderService.GetAllApprovedOrders();

            return Page();
        }

        public async Task<IActionResult> OnPostMarkDoneAsync(int id)
        {
            var order = await _guitarOrderService.GetGuitarOrder(id);
            if (order == null || order.OrderStatus != OrderStatuses.Approved)
                return NotFound();

            await _guitarOrderService.SetOrderStatus(id, OrderStatuses.Done);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            var order = await _guitarOrderService.GetGuitarOrder(id);
            if (order == null || order.OrderStatus != OrderStatuses.Approved)
                return NotFound();

            await _guitarOrderService.SetOrderStatus(id, OrderStatuses.Cancelled);

            return RedirectToPage();
        }
    }
}
