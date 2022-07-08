
using FoodOrder.Infrastructure.SeedWorks;

namespace FoodOrder.Application.SeedWorks
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IRepository<T> Repository<T>() where T : class
        {
            return UnitOfWork.Repository<T>();
        }
    }
}