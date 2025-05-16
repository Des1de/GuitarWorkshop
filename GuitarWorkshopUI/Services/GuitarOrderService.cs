using GuitarWorkshopUI.Constants;
using GuitarWorkshopUI.DTO;
using GuitarWorkshopUI.Interfaces;
using GutarWorkshopDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarWorkshopUI.Services
{
    public class GuitarOrderService : IGuitarOrderService
    {
        private readonly IDbContextFactory<GuitarWorkshopContext> _dbContextFactory;
        public GuitarOrderService(IDbContextFactory<GuitarWorkshopContext> dbContextFactory)
        { 
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateOrder(GuitarOrderDTO orderDTO)
        {
            GuitarOrder order = new()
            {
                OrderDateTime = orderDTO.OrderDateTime,
                BuildId = orderDTO.BuildId,
                OrderStatus = orderDTO.OrderStatus,
                Price = orderDTO.Price,
                UserId = orderDTO.UserId,
                DeliveryAddress = orderDTO.DeliveryAddress,
                PhoneNumber = orderDTO.PhoneNumber,
                Email = orderDTO.Email,
            };

            var context = _dbContextFactory.CreateDbContext();
            context.GuitarOrders.Add(order);   
            await context.SaveChangesAsync();
        }

        public async Task<List<GuitarOrderDTO>> GetAllApprovedOrders()
        {
            var context = _dbContextFactory.CreateDbContext();
            var orders = await context.GuitarOrders.Where(x => x.OrderStatus == OrderStatuses.Approved).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId = x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).OrderByDescending(x => x.OrderDateTime).ToListAsync();

            return orders;
        }

        public async Task<List<GuitarOrderDTO>> GetAllCancelledOrders()
        {
            var context = _dbContextFactory.CreateDbContext();
            var orders = await context.GuitarOrders.Where(x => x.OrderStatus == OrderStatuses.Cancelled).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId = x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).OrderByDescending(x => x.OrderDateTime).ToListAsync();

            return orders;
        }

        public async Task<List<GuitarOrderDTO>> GetAllDoneOrders()
        {
            var context = _dbContextFactory.CreateDbContext();
            var orders = await context.GuitarOrders.Where(x => x.OrderStatus == OrderStatuses.Done).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId = x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).OrderByDescending(x => x.OrderDateTime).ToListAsync();

            return orders;
        }

        public async Task<List<GuitarOrderDTO>> GetAllPendingOrders()
        {
            var context = _dbContextFactory.CreateDbContext();
            var orders = await context.GuitarOrders.Where(x => x.OrderStatus == OrderStatuses.Pending).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId = x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).OrderByDescending(x => x.OrderDateTime).ToListAsync();

            return orders;
        }

        public async Task<GuitarOrderDTO> GetGuitarOrder(int orderId)
        {
            var context = _dbContextFactory.CreateDbContext();
            var order = await context.GuitarOrders.Where(x => x.OrderId == orderId).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId = x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).FirstAsync();
            return order;
        }

        public async Task<List<GuitarOrderDTO>> GetOrdersByUserId(int userId)
        {
            var context = _dbContextFactory.CreateDbContext();
            var orders = await context.GuitarOrders.Where(x => x.UserId == userId).Select(x => new GuitarOrderDTO
            {
                OrderId = x.OrderId,
                BuildId=x.BuildId,
                OrderStatus = x.OrderStatus,
                Price = x.Price,
                UserId = x.UserId,
                OrderDateTime = x.OrderDateTime,
                DeliveryAddress = x.DeliveryAddress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            }).OrderByDescending(x => x.OrderDateTime).ToListAsync();

            return orders; 
        }

        public async Task SetOrderStatus(int orderId, string status)
        {
            var context = _dbContextFactory.CreateDbContext();
            await context.GuitarOrders.Where(x => orderId == x.OrderId)
                .ExecuteUpdateAsync(x => x.SetProperty(a => a.OrderStatus, status));
        }
    }
}
