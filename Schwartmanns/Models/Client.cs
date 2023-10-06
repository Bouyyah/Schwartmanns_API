namespace Schwartmanns.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
