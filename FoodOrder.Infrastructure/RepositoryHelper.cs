using FoodOrder.Infrastructure.SeedWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Infrastructure
{
    public static class RepositoryHelper
    {
        public static IQueryable<T> Where<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return repository.Entities.Where(predicate);
        }

        public static async Task<List<T>> ToListAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return await repository.Entities.Where(predicate).ToListAsync();
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return await repository.Entities.FirstOrDefaultAsync(predicate);
        }

        public static async Task<T> FirstAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return await repository.Entities.FirstAsync(predicate);
        }

        public static async Task<bool> AnyAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return await repository.Entities.AnyAsync(predicate);
        }

        public static async Task<int> CountAsync<T>(this IRepository<T> repository, Expression<Func<T, bool>> predicate) where T : class
        {
            return await repository.Entities.CountAsync(predicate);
        }

        public static IIncludableQueryable<T, TProperty> Include<T, TProperty>(this IRepository<T> repository, Expression<Func<T, TProperty>> path) where T : class
        {
            return repository.Entities.Include(path);
        }

        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : class
        {
            return await query.Where(predicate).ToListAsync();
        }

        public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : class
        {
            return await query.Where(predicate).FirstOrDefaultAsync();
        }
    }
}
