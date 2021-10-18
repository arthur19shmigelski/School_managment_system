namespace School.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository Courses { get; }
    }
}
