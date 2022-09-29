using Figures.Abstract;

namespace Figures.Factories.Abstract
{
    /// <summary>
    /// Geometric figure factory
    /// </summary>
    public interface IGeometricFigureFactory
    {
        /// <summary>
        /// Create figure
        /// </summary>
        /// <returns>Geometric figure</returns>
        IGeometricFigure CreateFigure();
    }
}
