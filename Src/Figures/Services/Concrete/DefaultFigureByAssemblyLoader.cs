using Figures.Abstract;
using Figures.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Figures.Services.Concrete
{
    /// <summary>
    /// Service for load one default instanse of every type in asseblies in directory
    /// </summary>
    public class DefaultFigureByAssemblyLoader : IFigureByAssemblyLoader
    {
        /// <summary>
        /// Directory path
        /// </summary>
        private readonly ITypesFromAssembliesLoader _TypesFromAssembliesLoader;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="typesFromAssembliesLoader">Service for load types from dll assemblies</param>
        public DefaultFigureByAssemblyLoader(ITypesFromAssembliesLoader typesFromAssembliesLoader)
        {
            _TypesFromAssembliesLoader = typesFromAssembliesLoader
                ?? throw new ArgumentNullException(nameof(typesFromAssembliesLoader));
        }

        /// <inheritdoc/>
        public IList<IGeometricFigure> LoadFigures()
        {
            var figureTypes = _TypesFromAssembliesLoader.LoadTypes().Where(type => type.IsClass
                    && typeof(IGeometricFigure).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()));

            var defaultFigures = figureTypes.Select(type => Activator.CreateInstance(type) as IGeometricFigure).ToList();
            defaultFigures.ForEach(figure => figure?.DefaultInitialize());

            return defaultFigures;
        }
    }
}
