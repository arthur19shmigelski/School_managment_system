using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Angular.Dto;
using School.BLL.Services.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> Get()
        {
            return _mapper.Map<IEnumerable<CourseDto>>(await _service.GetAll());
        }
    }
}
