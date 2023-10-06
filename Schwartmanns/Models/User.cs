namespace Schwartmanns.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Type { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
