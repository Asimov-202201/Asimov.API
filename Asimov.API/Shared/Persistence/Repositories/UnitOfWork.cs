using System.Threading.Tasks;
using Asimov.API.Shared.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;

namespace Asimov.API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}