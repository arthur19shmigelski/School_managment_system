using School.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> Filter(Core.Models.Filters.CourseFilter filter);
    }
}
