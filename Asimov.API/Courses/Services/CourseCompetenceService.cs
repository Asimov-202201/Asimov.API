using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Competences.Domain.Models;
using Asimov.API.Competences.Domain.Repositories;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Courses.Domain.Services;

namespace Asimov.API.Courses.Services
{
    public class CourseCompetenceService : ICourseCompetenceService
    {
        private readonly ICourseCompetenceRepository _courseCompetenceRepository;
        private readonly ICompetenceRepository _competenceRepository;


        public CourseCompetenceService(ICourseCompetenceRepository courseCompetenceRepository, ICompetenceRepository competenceRepository)
        {
            _courseCompetenceRepository = courseCompetenceRepository;
            _competenceRepository = competenceRepository;
        }

        public async Task<IEnumerable<Competence>> ListByCourseId(int courseId)
        {
            var courseCompetence = await _courseCompetenceRepository.FindByCourseId(courseId);
            IEnumerable<Competence> competences = new List<Competence>();

            foreach (var c in courseCompetence)
            {
                var competence = await _competenceRepository.FindByIdAsync(c.CompetenceId);
                competences = competences.Append(competence);
            }

            return competences.ToList();
        }
    }
}