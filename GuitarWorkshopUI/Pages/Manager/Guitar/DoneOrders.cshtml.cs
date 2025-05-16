using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarWorkshopUI.Pages.Manager.Guitar
{
    [Authorize(Roles = "Manager")]
    public class DoneOrdersModel : PageModel
    {
        private readonly IGuitarOrderService _guitarOrderService;

        public DoneOrdersModel(IGuitarOrderService guitarOrderService)
        {
            _guitarOrderService = guitarOrderService;
        }
        public List<GuitarOrderDTO> DoneOrders { get; set; } = new();

        public async Task OnGetAsync()
        {
            DoneOrders = await _guitarOrderService.GetAllDoneOrders();
        }
    }
}
