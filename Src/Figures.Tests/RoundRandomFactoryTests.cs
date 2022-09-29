using Figures.Concrete;
using Figures.Factories.Concrete;
using NUnit.Framework;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for RoundRandomFactory
    /// </summary>
    public class RoundRandomFactoryTests
    {
        [Test]
        public void CreateRandomRound()
        {
            var roundRandomFactory = new RoundRandomFactory();
            var randomRound = roundRandomFactory.CreateFigure() as Round;

            Assert.NotNull(randomRound);
            Assert.IsTrue(randomRound.Radius >= 0 && randomRound.Radius < Round.DefaultRadius);
        }
    }
}
