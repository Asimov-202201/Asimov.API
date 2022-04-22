using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Domain.Services;
using Asimov.API.Courses.Resources;
using Asimov.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Courses.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllAsync()
        {
            var courses = await _courseService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<CourseResource> GetByIdAsync(int id)
        {
            var course = await _courseService.FindByIdAsync(id);
            var resource = _mapper.Map<Course, CourseResource>(course);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);

            var result = await _courseService.SaveAsync(course);
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);

            return Ok(courseResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);

            var result = await _courseService.UpdateAsync(id, course);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            
            return Ok(courseResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _courseService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            
            return Ok(courseResource);
        }
    }
}