using FoodOrder.Entity.Entities;
using FoodOrder.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Infrastructure.Repositories
{
    public static class UserRepository
    {
        public static async Task<IList<User>> GetTenant(this IRepository<User> repository, int userNo, int agencyNo)
        {
            return await repository.ToListAsync(_ => _.Active);
        }
    }
}
