using GuitarWorkshopUI.Constants;
using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GuitarWorkshopUI.Pages.Order
{
    [Authorize(Roles = "User")]
    public class CreateGuitarOrderModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;
        private readonly IGuitarBuildService _guitarBuildService;
        public CreateGuitarOrderModel(IGuitarOrderService guitarOrderService, IGuitarBuildService guitarBuildService)
        {
            _guitarOrderService = guitarOrderService;
            _guitarBuildService = guitarBuildService;
        }
        [BindProperty]
        public GuitarOrderDTO GuitarOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int buildId)
        {
            var build = await _guitarBuildService.GetGuitarBuild(buildId);
            if (build == null)
                return NotFound();

            GuitarOrder = new GuitarOrderDTO
            {
                BuildId = buildId,
                OrderDateTime = DateTime.Now,
                Price = build.TotalPrice,
                OrderStatus = OrderStatuses.Pending
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string userId = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userId, out int id))
            {
                return Unauthorized();
            }

            GuitarOrder.UserId = id;
            GuitarOrder.OrderDateTime = DateTime.Now;

            var build = await _guitarBuildService.GetGuitarBuild(GuitarOrder.BuildId);
            if (build == null)
                return NotFound();
            GuitarOrder.Price = build.TotalPrice;

            await _guitarOrderService.CreateOrder(GuitarOrder);

            return RedirectToPage("/Order/UserGuitarOrders");
        }
    }
}
