using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Domain.Services;
using Asimov.API.Directors.Resources;
using Asimov.API.Security.Authorization.Attributes;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Directors.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorsController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("/auth/sign-in/director")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _directorService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("/auth/sign-up/director")]
        public async Task<IActionResult> Register(RegisterRequestDirector request)
        {
            await _directorService.RegisterAsync(request);
            return Ok(new {message = "Registration successful."});
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var directors = await _directorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Director>, IEnumerable<DirectorResource>>(directors);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var director = await _directorService.GetByIdAsync(id);
            var resource = _mapper.Map<Director, DirectorResource>(director);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequestDirector request)
        {
            await _directorService.UpdateAsync(id, request);
            return Ok(new {message = "User Updated Successfully."});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _directorService.DeleteAsync(id);
            return Ok(new {message = "User Deleted successfully."});
        }
    }
}