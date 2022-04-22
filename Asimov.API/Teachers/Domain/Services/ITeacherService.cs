using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Domain.Services.Communication;

namespace Asimov.API.Teachers.Domain.Services
{
    public interface ITeacherService
    {
        public Task<AuthenticateResponseTeacher> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<Teacher>> ListAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> FindByIdAsync(int id);
        Task<IEnumerable<Teacher>> ListByDirectorIdAsync(int directorId);
        public Task RegisterAsync(RegisterRequestTeacher request);
        public Task UpdateAsync(int id, UpdateRequestTeacher request);
        public Task DeleteAsync(int id);
    }
}