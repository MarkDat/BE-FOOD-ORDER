using System;
using System.Collections.Generic;

#nullable disable

namespace FoodOrder.Entity.Entities
{
    public partial class Agency
    {
        public Agency()
        {
            AgenciesUsers = new HashSet<AgenciesUser>();
        }

        public int AgencyNo { get; set; }
        public string AgencyCompanyName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<AgenciesUser> AgenciesUsers { get; set; }
    }
}
