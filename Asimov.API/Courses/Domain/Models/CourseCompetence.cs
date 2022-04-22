using Asimov.API.Competences.Domain.Models;

namespace Asimov.API.Courses.Domain.Models
{
    public class CourseCompetence
    {
        public int CourseId { get; set; }
        public int CompetenceId { get; set; }
        
        public Course Course { get; set; }
        public Competence Competence { get; set; }
    }
}