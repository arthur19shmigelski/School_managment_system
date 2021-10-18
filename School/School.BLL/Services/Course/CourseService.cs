using School.BLL.Extensions;
using School.Core.Models.Filters;
using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Core.Models.Course>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Core.Models.Course> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Core.Models.Course course)
        {
            await _repository.Create(course);
        }

        public async Task Update(Core.Models.Course course)
        {
            await _repository.Update(course);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Core.Models.Course>> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _repository.GetAll();
            return await _repository.Find(c =>
                c.Title.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase) ||
                c.Description.Contains(search.NormalizeSearchString(), StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<object>> Filter(CourseFilter filter)
        {
            var filteredCourses = await _repository.Filter(filter);

            return filteredCourses;
        }

        public async Task<PageList<Core.Models.Course>> GetByPages(QueryOptions options)
        {
            return await _repository.GetByPages(options);
        }
    }
}