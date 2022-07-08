using System.ComponentModel.DataAnnotations.Schema;
using FoodOrder.Entity.SeedWorks;

namespace FoodOrder.Entity.Entities.Orders
{
    [Table("OrderProductItem")]
    public class OrderProductItem : EntityBase
    {
        public virtual Product Product { get; }
        public long Price { get; }
        public int Quantity { get; }

        public OrderProductItem()
        {
        }

        public OrderProductItem(Product product, int quantity)
        {
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }
    }
}