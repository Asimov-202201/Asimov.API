using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Items.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Items.Persistence.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> ListAsync()
        {
            return await _context.Items
                .Include(p => p.Course)
                .ToListAsync();
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await _context.Items
                .Include(p => p.Course)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Item>> FindByCourseId(int courseId)
        {
            return await _context.Items
                .Where(p => p.CourseId == courseId)
                .Include(p => p.Course)
                .ToListAsync();
        }

        public void Update(Item item)
        {
            _context.Items.Update(item);
        }

        public void Remove(Item item)
        {
            _context.Items.Remove(item);
        }
    }
}