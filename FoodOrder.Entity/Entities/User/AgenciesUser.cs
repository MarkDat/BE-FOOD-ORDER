using System;
using System.Collections.Generic;

#nullable disable

namespace FoodOrder.Entity.Entities
{
    public partial class AgenciesUser
    {
        public int AgencyUserNo { get; set; }
        public int AgencyNo { get; set; }
        public int UserNo { get; set; }

        public virtual Agency AgencyNoNavigation { get; set; }
        public virtual User UserNoNavigation { get; set; }
    }
}
