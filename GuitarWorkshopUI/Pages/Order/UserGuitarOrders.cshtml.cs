using GuitarWorkshopUI.Constants;
using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace GuitarWorkshopUI.Pages.Order
{
    [Authorize(Roles = "User")]
    public class UserGuitarOrdersModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;

        public UserGuitarOrdersModel(IGuitarOrderService guitarOrderService)
        {
            _guitarOrderService = guitarOrderService;
        }

        public List<GuitarOrderDTO> UserOrders { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string userId = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userId, out int id))
            {
                return Unauthorized();
            }


            UserOrders = await _guitarOrderService.GetOrdersByUserId(id);

            return Page();
        }

        public async Task<IActionResult> OnPostCancelAsync(int orderId)
        {
            string userId = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userId, out int id))
            {
                return Unauthorized();
            }

            var order = await _guitarOrderService.GetGuitarOrder(orderId);

            if (order == null)
                return NotFound();

            if (order.OrderStatus != OrderStatuses.Pending)
                return BadRequest("Order cannot be cancelled.");

            await _guitarOrderService.SetOrderStatus(orderId, OrderStatuses.Cancelled);

            return RedirectToPage();
        }
    }
}
