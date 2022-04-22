using Asimov.API.Courses.Domain.Models;

namespace Asimov.API.Items.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Value { get; set; }
        
        public bool State { get; set; }
        
        // Relationships
        
        public int CourseId { get; set; }
        
        public Course Course { get; set; }
    }
}