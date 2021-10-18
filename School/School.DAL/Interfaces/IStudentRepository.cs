using School.Core.Models;
using School.Core.Models.Pages;
using System.Threading.Tasks;

namespace School.DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<PageList<Student>> GetByPages(QueryOptions options);
    }
}
