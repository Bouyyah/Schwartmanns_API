namespace Schwartmanns.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int MaterialID { get; set; }
        public int ProjectID { get; set; }

        public Project? Project { get; set; }

        public ICollection<Sheet>? Sheets { get; set; }
    }
}
