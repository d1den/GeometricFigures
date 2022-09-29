using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Figures.Services.Concrete
{
    /// <summary>
    /// Service for load types from dll assemblies
    /// </summary>
    public class TypesFromAssembliesLoader
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
        public TypesFromAssembliesLoader(string assembliesDirectoryPath)
        {
            _AssembliesDirectoryPath = assembliesDirectoryPath
                ?? throw new ArgumentNullException(nameof(assembliesDirectoryPath));
        }

        /// <inheritdoc/>
        public IList<Type> LoadTypes()
        {
            if (!Directory.Exists(_AssembliesDirectoryPath))
            {
                return new List<Type>();
            }

            var assemblyFiles = Directory.EnumerateFiles(_AssembliesDirectoryPath, _DllFileNamePattern);
            var assemblies = assemblyFiles.Select(file => Assembly.LoadFrom(file));
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                types.AddRange(assembly.ExportedTypes);
            }

            return types;
        }
    }
}
