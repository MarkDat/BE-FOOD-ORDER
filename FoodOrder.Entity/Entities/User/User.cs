using System;
using System.Collections.Generic;

#nullable disable

namespace FoodOrder.Entity.Entities
{
    public partial class User
    {
        public User()
        {
            AgenciesUsers = new HashSet<AgenciesUser>();
            UsersRoles = new HashSet<UsersRole>();
        }

        public int UserNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Current { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string PasswordPin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<AgenciesUser> AgenciesUsers { get; set; }
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
