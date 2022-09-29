using Figures.Abstract;
using System.Collections.Generic;

namespace Figures.Services.Abstract
{
    /// <summary>
    /// Service for load figures by assemly
    /// </summary>
    public interface IFigureByAssemblyLoader
    {
        /// <summary>
        /// Load figures
        /// </summary>
        /// <returns>List of figures</returns>
        IList<IGeometricFigure> LoadFigures();
    }
}
