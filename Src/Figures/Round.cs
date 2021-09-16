using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    /// <summary>
    /// Round - geometric figure
    /// </summary>
    public class Round : IFigure
    {
        private readonly double _radius;
        /// <summary>
        /// Get radius of round
        /// </summary>
        public double Radius => _radius;
        /// <summary>
        /// Create round object
        /// </summary>
        /// <param name="radius">Radius of round</param>
        /// <exception cref="ArgumentOutOfRangeException">If radius is negative</exception>
        public Round(double radius)
        {
            if(radius < 0)
            {
                var ex = new ArgumentOutOfRangeException("Radius can`t be negative!");
                ex.Data.Add("Radius", radius);
                throw ex;
            }
            _radius = radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2.0);
        }
    }
}
