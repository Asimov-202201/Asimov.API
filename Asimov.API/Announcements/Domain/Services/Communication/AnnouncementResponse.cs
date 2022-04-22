using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Shared.Domain.Services.Communication;

namespace Asimov.API.Announcements.Domain.Services.Communication
{
    public class AnnouncementResponse : BaseResponse<Announcement>
    {
        public AnnouncementResponse(string message) : base(message)
        {
        }

        public AnnouncementResponse(Announcement resource) : base(resource)
        {
        }
    }
}