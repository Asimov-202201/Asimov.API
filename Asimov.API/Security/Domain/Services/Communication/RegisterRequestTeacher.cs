namespace Asimov.API.Security.Domain.Services.Communication
{
    public class RegisterRequestTeacher
    {
        public int Point { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int DirectorId { get; set; }
    }
}