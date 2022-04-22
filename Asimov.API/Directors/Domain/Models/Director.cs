using System.Collections.Generic;
using System.Text.Json.Serialization;
using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Teachers.Domain.Models;

namespace Asimov.API.Directors.Domain.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Phone { get; set; }

        public IList<Announcement> Announcements { get; set; } = new List<Announcement>();
        public IList<Teacher> Teachers { get; set; } = new List<Teacher>();
        
    }
}