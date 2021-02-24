using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marvello.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(long id);
        Task<T> GetOne(int id);
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}