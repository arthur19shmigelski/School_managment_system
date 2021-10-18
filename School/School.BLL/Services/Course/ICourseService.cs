using School.BLL.Services.Base;
using School.Core.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Course
{
    public interface ICourseService : IEntityService<Core.Models.Course>
    {
        Task<IEnumerable<Core.Models.Course>> Search(string search);
        Task<IEnumerable<object>> Filter(CourseFilter filter);
    }
}