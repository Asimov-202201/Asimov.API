namespace Asimov.API.Items.Resources
{
    public class ItemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool State { get; set; }
        
        public int CourseId { get; set; }
    }
}