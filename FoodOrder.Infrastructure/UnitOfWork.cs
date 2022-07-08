using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodOrder.Infrastructure.SeedWorks;
using System.Collections.Generic;
using FoodOrder.Entity.Contexts;

namespace FoodOrder.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FoodOrderContext _appDbContext;
        private Dictionary<string, object> Repositories { get; }

        public UnitOfWork(FoodOrderContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<int> SaveChangeAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }
        
        public async Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func)
        {
            var strategy = _appDbContext.Database.CreateExecutionStrategy();
            var transResult = await strategy.ExecuteAsync(async () =>
            {
                using (var trans = await _appDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var result = await func.Invoke();

                        await SaveChangeAsync();
                        await trans.CommitAsync();
                        return result;
                    }
                    catch (Exception)
                    {
                        await trans.RollbackAsync();
                        throw;
                    }
                }
            });
            return transResult;
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _appDbContext.Dispose();
            }
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            var typeName = type.Name;

            lock (Repositories)
            {
                if (Repositories.ContainsKey(typeName))
                {
                    return (IRepository<T>)Repositories[typeName];
                }

                var repository = new Repository<T>(_appDbContext);

                Repositories.Add(typeName, repository);
                return repository;
            }
        }
    }

}