namespace Schwartmanns.Models
{
    public class Line
    {
        public int Id { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double Bulge { get; set; }

        public Sheet? Sheet { get; set; }
    }
}
