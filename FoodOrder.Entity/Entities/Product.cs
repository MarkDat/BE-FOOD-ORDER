using System.ComponentModel.DataAnnotations.Schema;
using FoodOrder.Entity.SeedWorks;

namespace FoodOrder.Entity.Entities
{
    [Table("Product")]
    public class Product : EntityBase
    {
        public int Name { get; set; }
        public long Price { get; set; }
        public int StockQuantity { get; set; }
    }
}