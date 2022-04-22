using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Announcements.Resources
{
    public class SaveAnnouncementResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        
        [Required]
        public int DirectorId { get; set; }
    }
}