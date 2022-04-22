using System.Collections.Generic;
using Asimov.API.Directors.Domain.Models;
using Newtonsoft.Json;

namespace Asimov.API.Teachers.Domain.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        
        // Relationships
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public IList<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();
    }
}