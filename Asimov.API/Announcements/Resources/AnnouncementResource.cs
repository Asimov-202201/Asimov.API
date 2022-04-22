namespace Asimov.API.Announcements.Resources
{
    public class AnnouncementResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public int DirectorId { get; set; }
    }
}