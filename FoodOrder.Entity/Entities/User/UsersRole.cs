using System;
using System.Collections.Generic;

#nullable disable

namespace FoodOrder.Entity.Entities
{
    public partial class UsersRole
    {
        public int UsersRoleNo { get; set; }
        public int UserNo { get; set; }
        public int RoleNo { get; set; }
        public int? AgencyNo { get; set; }

        public virtual RefRole RoleNoNavigation { get; set; }
        public virtual User UserNoNavigation { get; set; }
    }
}
