using Figures.Concrete;
using NUnit.Framework;
using System;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for round class
    /// </summary>
    public class RoundTests
    {
        [Test]
        public void CreateObject()
        {
            var round1 = new Round(4);
            Assert.AreEqual(round1.GetType(), typeof(Round));
            Assert.AreEqual(round1.Radius, 4);
        }
        [Test]
        public void CreateWrongObject()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Round(-2.34));
        }
        [Test]
        public void GetArea()
        {
            var round1 = new Round(4);
            Assert.AreEqual(round1.CalculateArea(), Math.PI * Math.Pow(4, 2));
        }
        [Test]
        public void GetAreaOfNullradius()
        {
            var round1 = new Round(0);
            Assert.AreEqual(round1.CalculateArea(), 0.0);
        }
        [Test]
        public void EqualsTest()
        {
            var round1 = new Round(4);
            var round2 = new Round(3.234);
            Round round3 = round1.Clone() as Round;
            Assert.True(round1.Equals(round3));
            Assert.True(round1.Equals(round2, 1.0));
            Assert.False(round1.Equals(round2));
            Assert.False(round1.Equals("round"));
        }
        [Test]
        public void HashCodeTest()
        {
            var round1 = new Round(4);
            var round2 = new Round(3.234);
            Round round3 = round1.Clone() as Round;
            Assert.AreEqual(round1.GetHashCode(), round1.GetHashCode());
            Assert.AreEqual(round1.GetHashCode(), round3.GetHashCode());
            Assert.AreNotEqual(round1.GetHashCode(), round2.GetHashCode());
        }

        [Test]
        public void DefaultInitialize()
        {
            var round = new Round();
            round.DefaultInitialize();
            Assert.AreEqual(round.Radius, Round.DefaultRadius);
        }
    }
}