using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Application.SeedWorks;
using System.Threading.Tasks;
using System.Collections.Generic;
using FoodOrder.Application.ViewModels.User;
using FoodOrder.Infrastructure.SeedWorks;
using FoodOrder.Entity.Entities;
using System.Linq;

namespace FoodOrder.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<User>> GetAll()
        {
            return await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                var users = await Repository<User>().GetAllAsync();
                return users.ToList();
            });
        }
    }
}
