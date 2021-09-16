using System;
using D1den.Calculation;

namespace Figures
{
    /// <summary>
    /// Triangle - geometric figure
    /// </summary>
    public class Triangle : IFigure, ICloneable, IEquatable<Triangle>
    {
        private readonly double _a, _b, _c;
        /// <summary>
        /// 1st side
        /// </summary>
        public double A => _a;
        /// <summary>
        /// 2nd side
        /// </summary>
        public double B => _b;
        /// <summary>
        /// 3d side
        /// </summary>
        public double C => _c;
        /// <summary>
        /// Is a triangle right-angled?
        /// </summary>
        public bool IsRightTriangle
        {
            get
            {
                if (_a > _b && _a > _c)
                    return PythagoreanTheoremIsTrue(_a, _b, _c);
                else if (_b > _a && _b > _c)
                    return PythagoreanTheoremIsTrue(_b, _a, _c);
                else if (_c > _a && _c > _b)
                    return PythagoreanTheoremIsTrue(_c, _a, _b);
                else
                    return false;
            }
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
            if(a <= 0 || b <= 0 || c <= 0)
            {
                var ex = new ArgumentOutOfRangeException("Side of triangle can`t be negative!");
                ex.Data.Add("A", a);
                ex.Data.Add("B", B);
                ex.Data.Add("C", C);
                throw ex;
            }
            _a = a;
            _b = b;
            _c = c;
        }
        public double GetArea()
        {
            double p = (_a + _b + _c) / 2.0;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }
        private bool PythagoreanTheoremIsTrue(double hypotenuse, double cathetus1, double cathetus2)
        {
            return MathA.CompareAlmostEqual(Math.Pow(hypotenuse, 2.0), 
                Math.Pow(cathetus1, 2.0) + Math.Pow(cathetus2, 2.0),
                1.0E-6);
        }

        public object Clone()
        {
            return new Triangle(_a, _b, _c);
        }
        /// <summary>
        /// Checking with some accuracy the equality
        /// </summary>
        public bool Equals(Triangle other, double delta)
        {
            if (MathA.CompareAlmostEqual(other._a, _a, delta) &&
                MathA.CompareAlmostEqual(other._b, _b, delta) &&
                MathA.CompareAlmostEqual(other._c, _c, delta))
                return true;
            else
                return false;
        }
        public bool Equals(Triangle other)
        {
            return Equals(other, 1.0E-6);
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (obj is Triangle other)
                return Equals(other);
            else
                return false;
        }
        public override int GetHashCode()
        {
            double result = _a * 1.0E+3 +
                   _b * 1.0E+2 + _c * 10;
            if (result > -1.0 && result < 1.0)
                result *= 1.0E+9;
            return (int)Math.Round(result);
        }
        public override string ToString()
        {
            return string.Format("{0:F2}, {1:F2}, {2:F2}", _a, _b, _c);
        }
    }
}
