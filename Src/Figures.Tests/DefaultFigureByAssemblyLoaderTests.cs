using Figures.Concrete;
using Figures.Services.Abstract;
using Figures.Services.Concrete;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for DefaultFigureByAssemblyLoader
    /// </summary>
    public class DefaultFigureByAssemblyLoaderTests
    {
        [Test]
        public void LoadFigures()
        {
            // Arrange
            var mockTypesFromAssembliesLoader = new Mock<ITypesFromAssembliesLoader>();
            mockTypesFromAssembliesLoader.Setup(m => m.LoadTypes())
                .Returns(new List<Type> { typeof(Round), typeof(Triangle) });
            var defaultFigureByAssemblyLoader = new DefaultFigureByAssemblyLoader(mockTypesFromAssembliesLoader.Object);

            // Act
            var defaultFigures = defaultFigureByAssemblyLoader.LoadFigures();

            // Assert
            foreach(var figure in defaultFigures) 
            {
                Assert.AreNotEqual(figure.CalculateArea(), 0.0);
            }
        }
    }
}
