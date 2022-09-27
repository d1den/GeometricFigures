using Figures.Abstract;
using Figures.Concrete;
using Figures.Factories.Abstract;
using System;

namespace Figures.Factories.Concrete
{
    /// <summary>
    /// Random triangle factory
    /// </summary>
    public class TriangleRandomFactory : IGeometricFigureFactory
    {
        /// <summary>
        /// Random object
        /// </summary>
        private readonly Random _Random = new Random();

        /// <inheritdoc/>
        public IGeometricFigure CreateFigure()
        {
            var randomA = _Random.Next(0, (int)Triangle.DefaultA);
            var randomB = _Random.Next(0, (int)Triangle.DefaultB);
            var randomC = _Random.Next(0, (int)Triangle.DefaultC);

            return new Triangle(randomA, randomB, randomC);
        }
    }
}
