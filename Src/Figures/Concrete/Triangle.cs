using D1den.Calculation;
using Figures.Abstract;
using System;
using System.Linq;

namespace Figures.Concrete
{
    /// <summary>
    /// Triangle - geometric figure
    /// </summary>
    public class Triangle : IGeometricFigure, ICloneable, IEquatable<Triangle>
    {
        /// <summary>
        /// Triangle sides
        /// </summary>
        private double _A, _B, _C;

        /// <summary>
        /// Default accuracy
        /// </summary>
        private const double _DefaultAccuracy = 1.0E-6;

        /// <summary>
        /// Default sides
        /// </summary>
        private const double _DefaultA = 10, _DefaultB = 10, _DefaultC = 16;

        /// <summary>
        /// To string template
        /// </summary>
        private const string _TriangleToStringTemplate = "{0:F2}, {1:F2}, {2:F2}";

        /// <summary>
        /// 1st side
        /// </summary>
        public double A
        {
            get { return _A; }
            set
            {
                _A = value > 0 
                    ? value 
                    : throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        /// <summary>
        /// 2nd side
        /// </summary>
        public double B
        {
            get { return _B; }
            set
            {
                _B = value > 0
                    ? value
                    : throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
        /// <summary>
        /// 3d side
        /// </summary>
        public double C
        {
            get { return _C; }
            set
            {
                _C = value > 0
                    ? value
                    : throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        /// <summary>
        /// Create triangle object
        /// </summary>
        public Triangle()
        {

        }

        /// <summary>
        /// Create triangle object
        /// </summary>
        /// <param name="a">1st side of triangle</param>
        /// <param name="b">2nd side of triangle</param>
        /// <param name="c">3d side of triangle</param>
        /// <exception cref="ArgumentOutOfRangeException">If side is negative</exception>
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <inheritdoc/>
        public double CalculateArea()
        {
            var p = (A + B + C) / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        /// <summary>
        /// Is a triangle right-angled?
        /// </summary>
        /// <returns>Result</returns>
        public bool IsRightTriangle()
        {
            var sides = new[] { A, B, C };
            var hypotenuse = sides.Max();
            var cathetus1 = sides.FirstOrDefault(s => s != hypotenuse);
            var cathetus2 = sides.LastOrDefault(s => s != hypotenuse);

            return IsPythagoreanTheorem(hypotenuse, cathetus1, cathetus2);
        }

        /// <summary>
        /// Check Pythagorean Theorem
        /// </summary>
        /// <param name="hypotenuse">Hypotenuse</param>
        /// <param name="cathetus1">Cathetus</param>
        /// <param name="cathetus2">Cathetus</param>
        /// <returns>Result</returns>
        private bool IsPythagoreanTheorem(double hypotenuse, double cathetus1, double cathetus2)
        {
            return MathA.CompareAlmostEqual(Math.Pow(hypotenuse, 2.0), 
                Math.Pow(cathetus1, 2.0) + Math.Pow(cathetus2, 2.0), _DefaultAccuracy);
        }

        /// <inheritdoc/>
        public object Clone()
        {
            return new Triangle(A, B, C);
        }

        /// <summary>
        /// Checking with some accuracy the equality
        /// </summary>
        public bool Equals(Triangle other, double delta)
        {
            if (other is null)
            {
                return false;
            }
            else if (MathA.CompareAlmostEqual(other.A, A, delta) 
                && MathA.CompareAlmostEqual(other.B, B, delta) 
                && MathA.CompareAlmostEqual(other.C, C, delta))
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Triangle other)
        {
            if (other is null)
            {
                return false;
            }

            return Equals(other, 1.0E-6);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            else if (obj is Triangle other)
            {
                return Equals(other);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var result = A * 1.0E+3 +
                   B * 1.0E+2 + C * 10;
            if (result > -1.0 && result < 1.0)
                result *= 1.0E+9;
            return (int)Math.Round(result);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(_TriangleToStringTemplate, A, B, C);
        }

        /// <inheritdoc/>
        public void DefaultInitialize()
        {
            A = _DefaultA;
            B = _DefaultB;
            C = _DefaultC;
        }
    }
}
