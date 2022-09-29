using Figures.Concrete;
using Figures.Factories.Concrete;
using NUnit.Framework;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for TriangleRandomFactory
    /// </summary>
    public class TriangleRandomFactoryTests
    {
        [Test]
        public void CreateRandomTriangle()
        {
            var triangleRandomFactory = new TriangleRandomFactory();
            var randomTriangle = triangleRandomFactory.CreateFigure() as Triangle;

            Assert.NotNull(randomTriangle);
            Assert.IsTrue(randomTriangle.A > 0 && randomTriangle.A < Triangle.DefaultA);
            Assert.IsTrue(randomTriangle.B > 0 && randomTriangle.B < Triangle.DefaultB);
            Assert.IsTrue(randomTriangle.C > 0 && randomTriangle.C < Triangle.DefaultC);
        }
    }
}
