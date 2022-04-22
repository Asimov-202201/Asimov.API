using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Directors.Persistence.Repositories
{
    public class DirectorRepository : BaseRepository, IDirectorRepository
    {
        public DirectorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Director>> ListAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
        }

        public async Task<Director> FindByIdAsync(int id)
        {
            return await _context.Directors.FindAsync(id);
        }

        public async Task<Director> FindByEmailAsync(string email)
        {
            return await _context.Directors.SingleOrDefaultAsync(p => p.Email == email);
        }

        public bool ExistByEmail(string email)
        {
            return _context.Directors.Any(p => p.Email == email);
        }

        public Director FindById(int id)
        {
            return _context.Directors.Find(id);
        }

        public void Update(Director director)
        {
            _context.Directors.Update(director);
        }

        public void Remove(Director director)
        {
            _context.Directors.Remove(director);
        }
    }
}