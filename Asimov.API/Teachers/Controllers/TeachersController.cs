using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Resources;
using Asimov.API.Security.Authorization.Attributes;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Shared.Extensions;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Teachers.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeachersController : ControllerBase
    {
       private readonly ITeacherService _teacherService;
       private readonly IMapper _mapper;
       
       public TeachersController(ITeacherService teacherService, IMapper mapper)
       {
           _teacherService = teacherService;
           _mapper = mapper;
       }
       
       [AllowAnonymous]
       [HttpPost("/auth/sign-in/teacher")]
       public async Task<IActionResult> Authenticate(AuthenticateRequest request)
       {
           var response = await _teacherService.Authenticate(request);
           return Ok(response);
       }

       [AllowAnonymous]
       [HttpPost("/auth/sign-up/teacher")]
       public async Task<IActionResult> Register(RegisterRequestTeacher request)
       {
           await _teacherService.RegisterAsync(request);
           return Ok(new {message = "Registration successful."});
       }
        
       [HttpGet]
       public async Task<IActionResult> GetAll()
       {
           var teachers = await _teacherService.ListAsync();
           var resources = _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResource>>(teachers);
           return Ok(resources);
       }

       [HttpGet("{id}")]
       public async Task<IActionResult> GetById(int id)
       {
           var teacher = await _teacherService.GetByIdAsync(id);
           var resource = _mapper.Map<Teacher, TeacherResource>(teacher);
           return Ok(resource);
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> Update(int id, UpdateRequestTeacher request)
       {
           await _teacherService.UpdateAsync(id, request);
           return Ok(new {message = "User Updated Successfully."});
       }

       [HttpDelete("{id}")]
       public async Task<IActionResult> Delete(int id)
       {
           await _teacherService.DeleteAsync(id);
           return Ok(new {message = "User Deleted successfully."});
       }
    }
}