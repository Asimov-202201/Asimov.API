using System.ComponentModel.DataAnnotations;

namespace Asimov.API.Competences.Resources
{
    public class SaveCompetenceResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}