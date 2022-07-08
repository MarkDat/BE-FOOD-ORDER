using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FoodOrder.Entity.SeedWorks;

namespace FoodOrder.Entity.Entities.Basket
{
    [Table("Basket")]
    public class Basket : EntityBase
    {
        public int UserId { get; set; }
        public bool IsCheckedOut { get; set; }
        public virtual ICollection<BasketProductItem> Products { get; set; }

        public Basket(int userId)
        {
            UserId = userId;
        }
    }
}