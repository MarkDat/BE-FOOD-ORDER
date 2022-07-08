using System.Threading.Tasks;
using FoodOrder.Application.ViewModels.Order;
using FoodOrder.Entity.Entities.Orders;

namespace FoodOrder.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> Get(int id);
        public Task<Order> CreateOrder(OrderRequestVM orderInfo);
        public Task MarkOrderAsPaid(int orderId);
    }
}