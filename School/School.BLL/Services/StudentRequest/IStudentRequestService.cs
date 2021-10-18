using School.BLL.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.StudentRequest
{
    public interface IStudentRequestService : IEntityService<Core.Models.StudentRequest>
    {
        Task<IEnumerable<Core.Models.StudentRequest>> GetOpenRequestsByCourse(int courseId);
        Task<int> GetOpenRequestsCountByCourse(int courseId);
        Task<IEnumerable<Core.Models.Student>> GetStudentsByCourse(int courseId);
        Task<IEnumerable<Core.Models.StudentRequest>> GetAllOpen();
    }
}