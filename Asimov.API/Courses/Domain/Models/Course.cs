using System.Collections.Generic;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Courses.Domain.Models
{

    public class Course
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool State { get; set; }

        public IList<Item> Items { get; set; } = new List<Item>();
        public IList<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();
        public IList<CourseCompetence> CourseCompetences { get; set; } = new List<CourseCompetence>();
    }
}