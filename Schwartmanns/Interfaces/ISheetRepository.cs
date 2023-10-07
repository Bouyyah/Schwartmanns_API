namespace Schwartmanns.Interfaces
{
    public interface ISheetRepository
    {
        Dictionary<int, int> GetTotalCircles();
        Dictionary<int, int> GetTotalLines();

    }
}
