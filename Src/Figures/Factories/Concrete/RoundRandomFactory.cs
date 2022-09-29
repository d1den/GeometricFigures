using Figures.Abstract;
using Figures.Concrete;
using Figures.Factories.Abstract;
using System;

namespace Figures.Factories.Concrete
{
    /// <summary>
    /// Random round factory
    /// </summary>
    public class RoundRandomFactory : IGeometricFigureFactory
    {
        /// <summary>
        /// Random object
        /// </summary>
        private readonly Random _Random = new Random();

        /// <inheritdoc/>
        public IGeometricFigure CreateFigure()
        {
            var randomRadius = _Random.Next(0, (int)Round.DefaultRadius);
            return new Round(randomRadius);
        }
    }
}
