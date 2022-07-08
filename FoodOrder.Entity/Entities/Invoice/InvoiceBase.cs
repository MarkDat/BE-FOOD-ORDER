using FoodOrder.Entity.Entities.Orders;
using FoodOrder.Entity.SeedWorks;

namespace FoodOrder.Entity.Entities.Invoice
{
    public abstract class InvoiceBase : EntityBase
    {
        public Order Order { get; set; }
        public decimal TotalCost { get; set; }

        public abstract void Sign();
        
        protected InvoiceBase()
        {
        }

        protected InvoiceBase(Order order)
        {
            Order = order;
            TotalCost = order.Total();
        }

        public virtual string Export()
        {
            return $"Exported invoice with {nameof(TotalCost)}: {TotalCost}";
        }
    }
}