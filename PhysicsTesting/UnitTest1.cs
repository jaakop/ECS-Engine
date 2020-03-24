using System;
using MGPhysics;
using MGPhysics.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsTesting
{
    [TestClass]
    public class VectorMathTest
    {
        [TestMethod]
        public void VectorTest()
        {
            int a = 1;
            int b = 5;
            Vector testVector = new Vector(a, b);
            Assert.AreEqual(a, testVector.X, "Vector X coordinate not created correctly");
            Assert.AreEqual(b, testVector.Y, "Vector Y coordinate not created correctly");
        }
        [TestMethod]
        public void VectorSumTest()
        {
            Vector testVectorA = new Vector(1, 2);
            Vector testVectorB = new Vector(2, 3);

            Vector sumVector = testVectorA + testVectorB;
            Assert.AreEqual(testVectorA.X + testVectorB.X, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(testVectorA.Y + testVectorB.Y, sumVector.Y, "Vector Y coordinate not summed correctly");
        }
        [TestMethod]
        public void VectorSubtractionTest()
        {
            Vector testVectorA = new Vector(1, 2);
            Vector testVectorB = new Vector(2, 3);

            Vector sumVector = testVectorA - testVectorB;
            Assert.AreEqual(testVectorA.X - testVectorB.X, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(testVectorA.Y - testVectorB.Y, sumVector.Y, "Vector Y coordinate not subtracted correctly");
        }
        [TestMethod]
        public void NegativeVectorTest()
        {
            Vector testVectorA = new Vector(1, 2);
            Vector testVectorB = new Vector(2, 3);

            Vector sumVector = testVectorA + -testVectorB;
            Assert.AreEqual(testVectorA.X - testVectorB.X, sumVector.X, "Vector X coordinate not converted correctly");
            Assert.AreEqual(testVectorA.Y - testVectorB.Y, sumVector.Y, "Vector Y coordinate not converted correctly");
        }
    }
}
