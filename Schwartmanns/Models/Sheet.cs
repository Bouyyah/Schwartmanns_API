namespace Schwartmanns.Models
{
    public class Sheet
    {
        public int? Id { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? JobId { get; set; }
       

        public Job? Job { get; set; }

        public ICollection<Circle>? Circles { get; set; }
        public ICollection<Line>? Lines { get; set; }
    }
}
