using Figures.Enums;
using Figures.Factories.Abstract;

namespace Figures.Services.Abstract
{
    /// <summary>
    /// Figure factory provider
    /// </summary>
    public interface IFigureFactoryProvider
    {
        /// <summary>
        /// Get factory
        /// </summary>
        /// <param name="figureType">Type of figure</param>
        /// <returns>Factory</returns>
        IGeometricFigureFactory GetFactory(FigureTypeValues figureType);
    }
}
