using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Announcements.Domain.Services.Communication;

namespace Asimov.API.Announcements.Domain.Services
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task<IEnumerable<Announcement>> ListByDirectorIdAsync(int directorId);
        Task<AnnouncementResponse> SaveAsync(Announcement announcement);
        Task<AnnouncementResponse> UpdateAsync(int id, Announcement announcement);
        Task<AnnouncementResponse> DeleteAsync(int id);
    }
}