using Figures.Enums;
using Figures.Factories.Concrete;
using Figures.Services.Concrete;
using NUnit.Framework;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for FigureRandomFactoryProvider
    /// </summary>
    public class FigureRandomFactoryProviderTests
    {
        [Test]
        public void GetRoundRandomFactory()
        {
            var factoryProvider = new FigureRandomFactoryProvider();
            var roundFactory = factoryProvider.GetFactory(FigureTypeValues.Round);

            Assert.NotNull(roundFactory);
            Assert.IsTrue(roundFactory is RoundRandomFactory);
        }

        [Test]
        public void GetTriangleRandomFactory()
        {
            var factoryProvider = new FigureRandomFactoryProvider();
            var triangleFactory = factoryProvider.GetFactory(FigureTypeValues.Triangle);

            Assert.NotNull(triangleFactory);
            Assert.IsTrue(triangleFactory is TriangleRandomFactory);
        }
    }
}
