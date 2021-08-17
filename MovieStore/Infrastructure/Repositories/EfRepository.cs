using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetExistAsync(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
