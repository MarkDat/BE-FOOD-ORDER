using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.ViewModels.User
{
    public class UserResponseVM
    {
        public int UserNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Current { get; set; }
        public bool Active { get; set; }
    }
}
