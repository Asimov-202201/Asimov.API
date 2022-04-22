using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Domain.Services.Communication;
using Asimov.API.Security.Domain.Services.Communication;

namespace Asimov.API.Directors.Domain.Services
{
    public interface IDirectorService
    {
        public Task<AuthenticateResponseDirector> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<Director>> ListAsync();
        Task<Director> GetByIdAsync(int id);
        public Task RegisterAsync(RegisterRequestDirector request);
        public Task UpdateAsync(int id, UpdateRequestDirector request);
        public Task DeleteAsync(int id);
        }
}