using System.Threading.Tasks;
using FoodOrder.Entity.Entities.Orders;

namespace FoodOrder.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        public Task<int> CreateInvoice(Order order);
        public Task Sign(int orderId);
        public Task<string> Export(int orderId);
    }
}