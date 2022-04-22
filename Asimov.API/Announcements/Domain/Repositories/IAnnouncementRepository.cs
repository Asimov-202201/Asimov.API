using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Models;

namespace Asimov.API.Announcements.Domain.Repositories
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task AddAsync(Announcement announcement);
        Task<Announcement> FindByIdAsync(int id);
        Task<IEnumerable<Announcement>> FindByDirectorId(int directorId);
        void Update(Announcement announcement);
        void Remove(Announcement announcement);
    }
}