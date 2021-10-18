using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Base
{
    public class BaseEntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseEntityService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(TEntity entity)
        {
            await _repository.Create(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<PageList<TEntity>> GetByPages(QueryOptions options)
        {
            return await _repository.GetByPages(options);
        }
    }
}