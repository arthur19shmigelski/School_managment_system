using Microsoft.Extensions.DependencyInjection;
using School.Core.Models;
using School.DAL.EF.Repositories;
using School.DAL.Interfaces;

namespace School.DAL.EF.Extensions
{
    public static class ServicesExtensionsFromDalEf
    {
        public static IServiceCollection AddBusinessLogicServicesFromDalEF(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Topic>, TopicRepository>();
            services.AddScoped<ICourseRepository, CoursesRepository>();
            services.AddScoped<IRepository<Teacher>, TeachersRepository>();
            services.AddScoped<IStudentRepository, StudentsRepository>();
            services.AddScoped<IRepository<Group>, StudentGroupsRepository>();
            services.AddScoped<IRepository<StudentRequest>, StudentRequestsRepository>();

            return services;
        }
    }
}
