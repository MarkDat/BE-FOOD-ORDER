using System;
using System.Threading.Tasks;

namespace FoodOrder.Infrastructure.SeedWorks
{
    public interface IUnitOfWork    
    {   
        Task<int> SaveChangeAsync();   
		Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
        IRepository<T> Repository<T>() where T : class;
    }  
}