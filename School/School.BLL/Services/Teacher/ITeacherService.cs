using School.BLL.Services.Base;
using System.Threading.Tasks;

namespace School.BLL.Services.Teacher
{
    public interface ITeacherService : IEntityService<Core.Models.Teacher>
    {
        Task SavePhoto(int id, byte[] content);
    }
}