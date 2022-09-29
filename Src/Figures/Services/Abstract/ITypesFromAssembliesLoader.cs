using System;
using System.Collections.Generic;

namespace Figures.Services.Abstract
{
    /// <summary>
    /// Service for load types from dll assemblies
    /// </summary>
    public interface ITypesFromAssembliesLoader
    {
        /// <summary>
        /// Load types from assemblies in directory
        /// </summary>
        /// <returns>List of types</returns>
        IList<Type> LoadTypes();
    }
}
