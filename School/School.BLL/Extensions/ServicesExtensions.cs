using Microsoft.Extensions.DependencyInjection;
using School.BLL.Services.Course;
using School.BLL.Services.Student;
using School.BLL.Services.StudentGroup;
using School.BLL.Services.StudentRequest;
using School.BLL.Services.Teacher;
using School.BLL.Services.Topic;

namespace School.BLL.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddBusinessLogicServicesFromBLL(this IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentGroupService, StudentGroupService>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            return services;
        }
    }
}
