using Asimov.API.Directors.Domain.Models;

namespace Asimov.API.Announcements.Domain.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        // relationship
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}