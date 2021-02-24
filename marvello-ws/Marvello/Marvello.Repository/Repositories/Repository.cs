using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvello.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marvello.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MarvelloDBContext _context;

        public Repository(MarvelloDBContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetOne(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Save(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}