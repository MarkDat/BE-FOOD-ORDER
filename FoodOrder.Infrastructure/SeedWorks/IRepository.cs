using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrder.Infrastructure.SeedWorks
{
    public interface IRepository<T> where T : class   
    {
        DbSet<T> Entities { get; }

        DbContext DbContext { get; }

		T Find(params object[] keyValues);
		Task<T> FindAsync(params object[] keyValues);

		IEnumerable<T> GetAll();
		Task<IEnumerable<T>> GetAllAsync();

		void Insert(T entity);
		Task InsertAsync(T entity);
		Task InsertRangeAsync(IEnumerable<T> entities);
		void InsertRange(IEnumerable<T> entities);

		void Update(T entity);
		Task UpdateAsync(T entity);
		void UpdateRange(IEnumerable<T> entities);
		Task UpdateRangeAsync(IEnumerable<T> entities);

		void Delete(object id);
		void Delete(T entity);
		void DeleteRange(IEnumerable<T> entities);
		Task DeleteAsync(int id, bool saveChanges = true);
		Task DeleteAsync(T entity, bool saveChanges = true);
		Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
	}
}