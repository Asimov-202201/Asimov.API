using Asimov.API.Directors.Domain.Models;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateTokenForDirector(Director user);
        public string GenerateTokenForTeacher(Teacher teacher);
        public int? ValidateToken(string token);
    }
}