using System;

namespace Figures
{
    /// <summary>
    /// Round - geometric figure
    /// </summary>
    public class Round : IFigure, ICloneable, IEquatable<Round>
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

        public object Clone()
        {
            return new Round(_radius);
        }
        /// <summary>
        /// Checking with some accuracy the equality
        /// </summary>
        public bool Equals(Round other, double delta)
        {
            return D1den.Calculation.MathA.CompareAlmostEqual(other._radius, _radius, delta);
        }
        public bool Equals(Round other)
        {
            return Equals(other, 1.0E-6);
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (obj is Round other)
                return Equals(other);
            else
                return false;
        }
        public override int GetHashCode()
        {
            double result = _radius * 10;
            if (result > -1.0 && result < 1.0)
                result *= 1.0E+9;
            return (int)Math.Round(result);
        }
        public override string ToString()
        {
            return string.Format("R: {0:F2}", _radius);
        }
    }
}
