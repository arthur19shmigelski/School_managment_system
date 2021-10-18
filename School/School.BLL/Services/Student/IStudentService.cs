using School.BLL.Services.Base;
using School.Core.Models.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.BLL.Services.Student
{
    public interface IStudentService : IEntityService<Core.Models.Student>
    {
        //Task<PageList<Core.Models.Student>> GetByPages(QueryOptions options);

        Task<IEnumerable<Core.Models.Student>> Search(string search);
    }
}