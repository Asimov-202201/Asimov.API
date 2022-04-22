using System.Collections.Generic;
using System.Threading.Tasks;
using Asimov.API.Courses.Domain.Models;

namespace Asimov.API.Courses.Domain.Repositories
{
    public interface ICourseCompetenceRepository
    {
        public Task<IEnumerable<CourseCompetence>> FindByCourseId(int courseId);
    }
}