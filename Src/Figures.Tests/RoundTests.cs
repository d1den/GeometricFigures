using NUnit.Framework;
using System;

namespace Figures.Tests
{
    public class Tests
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
            TestDelegate testCode = delegate ()
            {
                var round1 = new Round(-2.34);
            };
            Assert.Throws<ArgumentOutOfRangeException>(testCode);
        }
        [Test]
        public void CreateInterfaceObject()
        {
            IFigure round1 = new Round(4);
            Assert.AreEqual(round1.GetType(), typeof(Round));
            Assert.AreEqual((round1 as Round).Radius, 4);
        }
        [Test]
        public void GetArea()
        {
            var round1 = new Round(4);
            Assert.AreEqual(round1.GetArea(), Math.PI * Math.Pow(4, 2));
        }
        [Test]
        public void GetAreaOfNullradius()
        {
            var round1 = new Round(0);
            Assert.AreEqual(round1.GetArea(), 0.0);
        }
        [Test]
        public void CloneTest()
        {
            var round1 = new Round(4);
            Round round2 = round1.Clone() as Round;
            Assert.AreEqual(round1.Radius, round2.Radius);
        }
        [Test]
        public void EqualsTest()
        {
            var round1 = new Round(4);
            var round2 = new Round(3.234);
            Round round3 = round1.Clone() as Round;
            Assert.True(round1.Equals(round3));
            Assert.True(!round1.Equals(round2));
            Assert.True(!round1.Equals("round"));
            Assert.True(round1.Equals(round2, 1.0));
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
    }
}