using GuitarWorkshopUI.DTO;

namespace GuitarWorkshopUI.Interfaces
{
    public interface IRepairOrderService
    {
        Task CreateOrder(RepairOrderDTO repairOrder);
        Task UpdateOrder(RepairOrderDTO repairOrder);
        Task DeleteOrder(RepairOrderDTO repairOrder);
        Task<RepairOrderDTO> GetOrder(int orderId);
        Task<RepairOrderDTO> GetOrders();
        Task<RepairOrderDTO> GetOrdersByUserId(int userId);
    }
}
