using School.Core.Models.Enum;
using School.Core.Models.Pages;
using School.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentRequest
{
    public class StudentRequestService : IStudentRequestService
    {
        private readonly IRepository<Core.Models.StudentRequest> _repository;

        public StudentRequestService(IRepository<Core.Models.StudentRequest> repository) 
        {
            _repository = repository;
        }

        public async Task Create(Core.Models.StudentRequest entity)
        {
            await _repository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Core.Models.StudentRequest>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Core.Models.StudentRequest>> GetAllOpen()
        {
            var allRequests =  await _repository.GetAll();
            return allRequests.Where(r => r.Status == RequestStatus.Open);
        }

        public async Task<Core.Models.StudentRequest> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<PageList<Core.Models.StudentRequest>> GetByPages(QueryOptions options)
        {
            return await _repository.GetByPages(options);
        }

        public async Task<IEnumerable<Core.Models.StudentRequest>> GetOpenRequestsByCourse(int courseId)
        {
            var allRequests = await _repository.GetAll();
            return allRequests.Where(r => r.CourseId == courseId && r.Status == RequestStatus.Open).ToList();
        }

        public async Task<int> GetOpenRequestsCountByCourse(int courseId)
        {
            var requests = await _repository.GetAll();
            return requests.Where(r => r.CourseId == courseId && r.Status == RequestStatus.Open)
                .Distinct()
                .ToList()
                .Count();
        }

        public async Task<IEnumerable<Core.Models.Student>> GetStudentsByCourse(int courseId)
        {
            var allRequests = await _repository.GetAll();

            return allRequests.Where(r => r.CourseId == courseId).Select(r => r.Student).Distinct();
        }

        public async Task Update(Core.Models.StudentRequest entity)
        {
            await _repository.Update(entity);
        }
    }
}