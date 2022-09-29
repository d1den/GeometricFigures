using Figures.Enums;
using Figures.Factories.Abstract;
using Figures.Factories.Concrete;
using Figures.Services.Abstract;
using System;

namespace Figures.Services.Concrete
{
    /// <summary>
    /// Random figure factory provider
    /// </summary>
    public class FigureRandomFactoryProvider : IFigureFactoryProvider
    {
        /// <inheritdoc/>
        public IGeometricFigureFactory GetFactory(FigureTypeValues figureType)
        {
            switch (figureType)
            {
                case FigureTypeValues.Round: return new RoundRandomFactory();
                case FigureTypeValues.Triangle: return new TriangleRandomFactory();
                default: throw new NotImplementedException(nameof(figureType));
            }
        }
    }
}
