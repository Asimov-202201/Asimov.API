using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Announcements.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Announcements.Persistence.Repositories
{
    public class AnnouncementRepository : BaseRepository, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _context.Announcements
                .Include(p => p.Director)
                .ToListAsync();
        }

        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcements.AddAsync(announcement);
        }

        public async Task<Announcement> FindByIdAsync(int id)
        {
            return await _context.Announcements
                .Include(p => p.Director)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Announcement>> FindByDirectorId(int directorId)
        {
            return await _context.Announcements
                .Where(p => p.DirectorId == directorId)
                .Include(p => p.Director)
                .ToListAsync();
        }

        public void Update(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
        }

        public void Remove(Announcement announcement)
        {
            _context.Announcements.Remove(announcement);
        }
    }
}