using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Security.Authorization.Attributes;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Directors.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/directors/{directorId}/teachers")]
    public class DirectorTeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public DirectorTeachersController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TeacherResource>> GetAllByDirectorIdAsync(int directorId)
        {
            var teachers = await _teacherService.ListByDirectorIdAsync(directorId);
            var resources = _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResource>>(teachers);

            return resources;
        }
    }
}