﻿using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
    public class CircleRepository : ICircleRepository
    {
        public CircleProperties CalculateCircleProperties(double radius)
        {
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
