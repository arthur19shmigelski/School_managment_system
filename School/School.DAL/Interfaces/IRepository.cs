using School.Core.Models.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Find(Func<T, Boolean> predicate);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<PageList<T>> GetByPages(QueryOptions options);
    }
}