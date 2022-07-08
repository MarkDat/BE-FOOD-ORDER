using System;
using System.Collections.Generic;

#nullable disable

namespace FoodOrder.Entity.Entities
{
    public partial class RefRole
    {
        public RefRole()
        {
            UsersRoles = new HashSet<UsersRole>();
        }

        public int RoleNo { get; set; }
        public string RoleName { get; set; }
        public bool Agency { get; set; }

        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
