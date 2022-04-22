using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Teachers.Resources
{
    public class SaveTeacherResource
    {
        
        [Required]
        public int Point { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }
        
        [Required]
        public int DirectorId { get; set; }
        
    }
}