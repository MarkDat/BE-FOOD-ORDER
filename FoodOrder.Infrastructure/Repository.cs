using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodOrder.Entity.SeedWorks;
using FoodOrder.Infrastructure.SeedWorks;
using System.Collections.Generic;
using System.Linq;
using FoodOrder.Entity.Contexts;

namespace FoodOrder.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
		public DbSet<T> Entities => DbContext.Set<T>();
		public DbContext DbContext { get; private set; }

		public Repository(FoodOrderContext dbContext)
        {
            DbContext = dbContext;
        }

		public void Delete(object id)
		{
			var entity = Entities.Find(id);
			Delete(entity);
		}

		public void Delete(T entity)
		{
			Entities.Remove(entity);

			DbContext.SaveChanges();

		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			Entities.RemoveRange(entities);

			DbContext.SaveChanges();
		}

		public T Find(params object[] keyValues)
		{
			return Entities.Find(keyValues);
		}

		public virtual async Task<T> FindAsync(params object[] keyValues)
		{
			return await Entities.FindAsync(keyValues);
		}

		public IEnumerable<T> GetAll()
		{
			return Entities.ToList();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await Entities.ToListAsync();
		}

		public void Insert(T entity)
		{
			Entities.Add(entity);
			DbContext.SaveChanges();
		}

		public async Task InsertAsync(T entity)
		{
			await Entities.AddAsync(entity);
			await DbContext.SaveChangesAsync();
		}

		public async Task InsertRangeAsync(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				await Entities.AddAsync(entity);
			}

			await DbContext.SaveChangesAsync();
		}

		public virtual void InsertRange(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				Insert(entity);
			}

			DbContext.SaveChanges();
		}

		public void Update(T entity)
		{
			Entities.Update(entity);

			DbContext.SaveChanges();
		}

		public async Task UpdateAsync(T entity)
		{
			await DbContext.SaveChangesAsync();
		}

		public async Task UpdateRangeAsync(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				await UpdateAsync(entity);
			}
		}

		public void UpdateRange(IEnumerable<T> entities)
		{
			Entities.UpdateRange(entities);

			DbContext.SaveChanges();
		}

		public async Task DeleteAsync(int id, bool saveChanges = true)
		{
			var entity = Entities.Find(id);

			if (entity != null)
			{
				await DeleteAsync(entity);
				if (saveChanges)
				{
					await DbContext.SaveChangesAsync();
				}
			}
		}

		public async Task DeleteAsync(T entity, bool saveChanges = true)
		{
			Entities.Remove(entity);

			if (saveChanges)
			{
				await DbContext.SaveChangesAsync();
			}
		}

		public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
		{
			if (entities.Any())
			{
				Entities.RemoveRange(entities);
			}

			if (saveChanges)
			{
				await DbContext.SaveChangesAsync();
			}
		}
	}
}