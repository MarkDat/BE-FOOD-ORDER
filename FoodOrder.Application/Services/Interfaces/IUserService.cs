using FoodOrder.Application.ViewModels.User;
using FoodOrder.Entity.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrder.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IList<User>> GetAll();
    }
}
