using AutoMapper;
using School.Angular.Dto;
using School.Core.Models;

namespace School.Angular.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
        }
    }
}
