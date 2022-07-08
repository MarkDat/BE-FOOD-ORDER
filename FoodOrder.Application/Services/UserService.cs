using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Application.SeedWorks;
using System.Threading.Tasks;
using System.Collections.Generic;
using FoodOrder.Application.ViewModels.User;
using FoodOrder.Infrastructure.SeedWorks;

namespace FoodOrder.Application.Services
{
    public class UserService : BaseService, IUser
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<UserResponseVM>> GetAll()
        {
            return await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                return new List<UserResponseVM>();
            });
        }
    }
}
