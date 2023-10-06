namespace Schwartmanns.Models
{
    public class Circle
    {
        public int Id { get; set; }
        public double? XPosition { get; set; }
        public double? YPosition { get; set; }
        public double? Radius { get; set; }

        public int SheetId { get; set; }


        public Sheet? Sheet { get; set; }
    }
}
