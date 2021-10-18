using AutoMapper;
using School.Core.Models;
using School.Web.API.Dto;

namespace School.Web.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
            CreateMap<Student, StudentDto>()
                .ReverseMap();
        }
    }
}