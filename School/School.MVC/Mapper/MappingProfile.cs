using AutoMapper;
using School.Core.Models;
using School.Core.Models.Filters;
using School.Core.ShortModels;

namespace School.MVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonModel>()
                .ReverseMap();
            CreateMap<Teacher, TeacherModel>()
                .ReverseMap();
            CreateMap<Student, StudentModel>()
                .ReverseMap();
            CreateMap<Group, StudentGroupModel>()
                //.ForMember(model => model.TeacherName, map => map.MapFrom(g => $"{g.Teacher.FirstName} {g.Teacher.LastName}"))
                .ReverseMap();
            CreateMap<Topic, TopicModel>()
                .ReverseMap();
            CreateMap<Course, CourseModel>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
            CreateMap<StudentRequest, StudentRequestModel>()
                .ForMember(model => model.StudentName, map => map.MapFrom(r => r.Student.FullName))
                .ForMember(model => model.CourseTitle, map => map.MapFrom(r => r.Course.Title))
                .ReverseMap();
            CreateMap<CourseFilter, CourseFilterModel>()
               .ReverseMap();
        }
    }
}