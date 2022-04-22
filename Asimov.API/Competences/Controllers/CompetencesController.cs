using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Competences.Domain.Models;
using Asimov.API.Competences.Domain.Services;
using Asimov.API.Competences.Resources;
using Asimov.API.Security.Authorization.Attributes;
using Asimov.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Competences.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [AuthorizeDirector]
    [AuthorizeTeacher]
    [Route("api/v1/[controller]")]
    public class CompetencesController : ControllerBase
    {
        private readonly ICompetenceService _competenceService;
        private readonly IMapper _mapper;

        public CompetencesController(ICompetenceService competenceService, IMapper mapper)
        {
            _competenceService = competenceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompetenceResource>> GetAllAsync()
        {
            var competences = await _competenceService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Competence>, IEnumerable<CompetenceResource>>(competences);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompetenceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var competence = _mapper.Map<SaveCompetenceResource, Competence>(resource);

            var result = await _competenceService.SaveAsync(competence);
            if (!result.Success)
                return BadRequest(result.Message);
            var competenceResource = _mapper.Map<Competence, CompetenceResource>(result.Resource);

            return Ok(competenceResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompetenceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var competence = _mapper.Map<SaveCompetenceResource, Competence>(resource);

            var result = await _competenceService.UpdateAsync(id, competence);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var competenceResource = _mapper.Map<Competence, CompetenceResource>(result.Resource);
            
            return Ok(competenceResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _competenceService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            var competenceResource = _mapper.Map<Competence, CompetenceResource>(result.Resource);
            
            return Ok(competenceResource);
        }
    }
}