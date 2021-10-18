using School.DAL.Interfaces;

namespace School.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICourseRepository _courses;
        public UnitOfWork(ICourseRepository courses)
        {
            _courses = courses;
        }

        public ICourseRepository Courses => _courses;
    }
}
