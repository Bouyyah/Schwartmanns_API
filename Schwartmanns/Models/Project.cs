namespace Schwartmanns.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }

        public User? User { get; set; }
        public Client? Client { get; set; }

        public ICollection<Job>? Jobs { get; set; }
    }
}
