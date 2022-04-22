namespace Asimov.API.Security.Domain.Services.Communication
{
    public class AuthenticateResponseDirector
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
    }
}