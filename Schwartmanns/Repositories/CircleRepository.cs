using Microsoft.EntityFrameworkCore;
using Schwartmanns.Data;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
    public class CircleRepository : ICircleRepository
    {
        private readonly DataContext _context;

        public CircleRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<Circle> GetCircleByIdAsync(int id)
        {
            return await _context.Circles.FirstOrDefaultAsync(c => c.Id == id);
        }
        public CircleProperties CalculateCircleProperties(int id)
        {
            double radius = (double)this.GetCircleByIdAsync(id).Result.Radius;
            double surfaceArea = Math.PI * Math.Pow(radius, 2);
            double circumference = 2 * Math.PI * radius;
            double diameter = 2 * radius;

            var circleProperties = new CircleProperties
            {
                SurfaceArea = surfaceArea,
                Circumference = circumference,
                Diameter = diameter
            };

            return circleProperties;
        }
    }

}
