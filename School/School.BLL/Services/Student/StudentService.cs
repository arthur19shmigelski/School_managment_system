using School.BLL.Extensions;
using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Core.Models.Student>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.Student> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Core.Models.Student student)
        {
            await _repository.Create(student);
        }

        public async Task Update(Core.Models.Student student)
        {
            await _repository.Update(student);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Core.Models.Student>> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _repository.GetAll();
            return await _repository.Find(c =>
                c.FirstName.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase) ||
                c.LastName.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase));
        }

        public async Task<PageList<Core.Models.Student>> GetByPages(QueryOptions options)
        {
            return await _repository.GetByPages(options);
        }
    }
}