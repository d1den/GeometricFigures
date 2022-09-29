using Figures.Concrete;
using NUnit.Framework;
using System;

namespace Figures.Tests
{
    /// <summary>
    /// Tests for Triangle class
    /// </summary>
    public class TriangleTests
    {
        [Test]
        public void CreateObject()
        {
            var triangle1 = new Triangle(4.5, 7, 3);
            Assert.AreEqual(triangle1.GetType(), typeof(Triangle));
            Assert.AreEqual(triangle1.A, 4.5);
            Assert.AreEqual(triangle1.B, 7);
            Assert.AreEqual(triangle1.C, 3);
        }
        [Test]
        public void CreateWrongObject()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-2.34, 1, 5));
        }
        [Test]
        public void GetArea()
        {
            var triangle1 = new Triangle(3, 4, 5);
            Assert.AreEqual(triangle1.CalculateArea(), 6);
        }
        [Test]
        public void EqualsTest()
        {
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4.56, 5);
            Triangle triangle3 = triangle1.Clone() as Triangle;
            Assert.True(triangle1.Equals(triangle3));
            Assert.True(!triangle1.Equals(triangle2));
            Assert.True(!triangle1.Equals("round"));
            Assert.True(triangle1.Equals(triangle2, 1.0));
        }
        [Test]
        public void HashCodeTest()
        {
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(3, 4.56, 5);
            Triangle triangle3 = triangle1.Clone() as Triangle;
            Assert.AreEqual(triangle1.GetHashCode(), triangle1.GetHashCode());
            Assert.AreEqual(triangle1.GetHashCode(), triangle3.GetHashCode());
            Assert.AreNotEqual(triangle1.GetHashCode(), triangle2.GetHashCode());
        }
        [Test]
        public void IsRightTriangle()
        {
            var triangle1 = new Triangle(3, 4, 5);
            var triangle2 = new Triangle(2, 4.56, 6);
            var triangle3 = new Triangle(5, 12, 13);
            Assert.AreEqual(triangle1.IsRightTriangle(), true);
            Assert.AreEqual(triangle2.IsRightTriangle(), false);
            Assert.AreEqual(triangle3.IsRightTriangle(), true);
        }

        [Test]
        public void DefaultInitialize()
        {
            var triangle1 = new Triangle();
            triangle1.DefaultInitialize();
            Assert.AreEqual(triangle1.A, Triangle.DefaultA);
            Assert.AreEqual(triangle1.B, Triangle.DefaultB);
            Assert.AreEqual(triangle1.C, Triangle.DefaultC);
        }
    }
}
