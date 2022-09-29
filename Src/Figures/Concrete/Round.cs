using D1den.Calculation;
using Figures.Abstract;
using System;

namespace Figures.Concrete
{
    /// <summary>
    /// Round - geometric figure
    /// </summary>
    public class Round : IGeometricFigure, ICloneable, IEquatable<Round>
    {
        /// <summary>
        /// Default accuracy
        /// </summary>
        private const double _DefaultAccuracy = 1.0E-6;

        /// <summary>
        /// To string template
        /// </summary>
        private const string _RoundToStringTemplate = "R: {0:F2}";

        /// <summary>
        /// Default radius
        /// </summary>
        public const double DefaultRadius = 10;

        /// <summary>
        /// Radius of round
        /// </summary>
        private double _Radius;

        /// <summary>
        /// Radius of round
        /// </summary>
        public double Radius
        {
            get { return _Radius; }
            set
            {
                _Radius = value >= 0 
                    ? value 
                    : throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        /// <summary>
        /// Create round object
        /// </summary>
        public Round()
        {

        }

        /// <summary>
        /// Create round object
        /// </summary>
        /// <param name="radius">Radius of round</param>
        /// <exception cref="ArgumentOutOfRangeException">If radius is negative</exception>
        public Round(double radius)
        {
            Radius = radius;
        }

        /// <inheritdoc/>
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2.0);
        }

        /// <inheritdoc/>
        public object Clone()
        {
            return new Round(Radius);
        }

        /// <summary>
        /// Checking with some accuracy the equality
        /// </summary>
        public bool Equals(Round other, double delta)
        {
            if (other is null)
            {
                return false;
            }
            return MathA.CompareAlmostEqual(other.Radius, Radius, delta);
        }

        /// <inheritdoc/>
        public bool Equals(Round other)
        {
            if (other is null)
            {
                return false;
            }

            return Equals(other, _DefaultAccuracy);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (obj is Round other)
            {
                return Equals(other);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var result = Radius * 10.0;
            if (result > -1.0 && result < 1.0)
                result *= 1.0E+9;
            return (int)Math.Round(result);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(_RoundToStringTemplate, Radius);
        }

        /// <inheritdoc/>
        public void DefaultInitialize()
        {
            Radius = DefaultRadius;
        }
    }
}
