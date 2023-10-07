using Schwartmanns.Models;

namespace Schwartmanns.Interfaces
{
    public interface ICircleRepository
    {
        CircleProperties CalculateCircleProperties(int id);
    }
}

