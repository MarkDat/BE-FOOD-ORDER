using FoodOrder.Application.ViewModels.User;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrder.Application.Services.Interfaces
{
    public interface IUser
    {
        public Task<IList<UserResponseVM>> GetAll();
    }
}
