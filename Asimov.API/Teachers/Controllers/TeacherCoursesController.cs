using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Resources;
using Asimov.API.Security.Authorization.Attributes;
using Asimov.API.Teachers.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Teachers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [AuthorizeDirector]
    [AuthorizeTeacher]
    [Route("/api/v1/teachers/{teacherId}/courses")]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly ITeacherCourseService _teacherCourseService;
        private readonly IMapper _mapper;

        public TeacherCoursesController(ITeacherCourseService teacherCourseService, IMapper mapper)
        {
            _teacherCourseService = teacherCourseService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllByTeacherIdAsync(int teacherId)
        {
            var courses = await _teacherCourseService.ListByTeacherId(teacherId);
            var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);

            return resources;
        }
    }
}