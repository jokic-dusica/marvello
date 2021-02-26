using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marvello.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marvello.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MarvelloDBContext _dbContext { get; set; }

        public Repository(MarvelloDBContext context)
        {
        
            _dbContext = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetOne(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Save(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
           return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}