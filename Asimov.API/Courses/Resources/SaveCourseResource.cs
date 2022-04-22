using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Courses.Resources
{
    public class SaveCourseResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public bool State { get; set; }
    }
}