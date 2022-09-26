namespace Figures.Abstract
{
    /// <summary>
    /// Geometric figure
    /// </summary>
    public interface IGeometricFigure
    {
        /// <summary>
        /// Calculate the area of a geometric figure
        /// </summary>
        /// <returns>Area</returns>
        double CalculateArea();

        /// <summary>
        /// Default initialize figure
        /// </summary>
        void DefaultInitialize();
    }
}
