using Figures.Concrete;
using Figures.Services.Concrete;
using NUnit.Framework;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for TypesFromAssembliesLoader
    /// </summary>
    public class TypesFromAssembliesLoaderTests
    {
        [Test]
        public void LoadTypes()
        {
            // Arrange
            // path is unique for your computer, replace it please
            var pathToFiguresDirrectory = @"C:\Users\ddenisov.NAVICONS\source\repos\GeometricFigures\Src\Figures\bin\Debug\netstandard2.0";
            var typesFromAssembliesLoader = new TypesFromAssembliesLoader(pathToFiguresDirrectory);

            // Act
            var types = typesFromAssembliesLoader.LoadTypes();
            var containsRound = types.Contains(typeof(Round));

            // Assert
            Assert.IsTrue(containsRound);
        }
    }
}
