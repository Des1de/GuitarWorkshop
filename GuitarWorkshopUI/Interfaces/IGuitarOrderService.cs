using GuitarWorkshopUI.DTO;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IGuitarOrderService
    {
        Task CreateOrder(GuitarOrderDTO orderDTO);
        Task SetOrderStatus(int orderId, string status);
        Task<GuitarOrderDTO> GetGuitarOrder(int orderId);
        Task<List<GuitarOrderDTO>> GetOrdersByUserId(int userId);
        Task<List<GuitarOrderDTO>> GetAllPendingOrders();
        Task<List<GuitarOrderDTO>> GetAllCancelledOrders();
        Task<List<GuitarOrderDTO>> GetAllApprovedOrders();
        Task<List<GuitarOrderDTO>> GetAllDoneOrders(); 
    }
}
