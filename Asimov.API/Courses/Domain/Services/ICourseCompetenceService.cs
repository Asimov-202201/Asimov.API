using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Competences.Domain.Models;

namespace Asimov.API.Courses.Domain.Services
{
    public interface ICourseCompetenceService
    {
        Task<IEnumerable<Competence>> ListByCourseId(int courseId);
    }
}