using Figures.Abstract;
using Figures.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// File name pattern for .dll
        /// </summary>
        private const string _DllFileNamePattern = "*.dll";

        /// <summary>
        /// Directory path
        /// </summary>
        private readonly string _AssembliesDirectoryPath;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="assembliesDirectoryPath">Directory path</param>
        public DefaultFigureByAssemblyLoader(string assembliesDirectoryPath)
        {
            _AssembliesDirectoryPath = assembliesDirectoryPath 
                ?? throw new ArgumentNullException(nameof(assembliesDirectoryPath));
        }

        /// <inheritdoc/>
        public IList<IGeometricFigure> LoadFigures()
        {
            var assemblyFiles = Directory.EnumerateFiles(_AssembliesDirectoryPath, _DllFileNamePattern);
            var assemblies = assemblyFiles.Select(file => Assembly.Load(file));
            var figureTypes = new List<Type>();
            foreach(var assembly in assemblies)
            {
                var types = assembly.ExportedTypes.Where(type => type.IsClass 
                    && typeof(IGeometricFigure).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()));
                figureTypes.AddRange(types);
            }

            var defaultFigures = figureTypes.Select(type => Activator.CreateInstance(type) as IGeometricFigure).ToList();
            defaultFigures.ForEach(figure => figure?.DefaultInitialize());

            return defaultFigures;
        }
    }
}
