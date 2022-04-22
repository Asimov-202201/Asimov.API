using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Announcements.Domain.Services;
using Asimov.API.Announcements.Resources;
using Asimov.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asimov.API.Announcements.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AnnouncementResource>> GetAllAsync()
        {
            var announcements = await _announcementService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(announcements);
            
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAnnouncementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var announcement = _mapper.Map<SaveAnnouncementResource, Announcement>(resource);

            var result = await _announcementService.SaveAsync(announcement);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAnnouncementResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var announcement = _mapper.Map<SaveAnnouncementResource, Announcement>(resource);

            var result = await _announcementService.UpdateAsync(id, announcement);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _announcementService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);

            return Ok(announcementResource);
        }
    }
}