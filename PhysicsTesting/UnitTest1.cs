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
            IntVector testVector = new IntVector(a, b);
            Assert.AreEqual(a, testVector.X, "Vector X coordinate not created correctly");
            Assert.AreEqual(b, testVector.Y, "Vector Y coordinate not created correctly");
        }
        [TestMethod]
        public void VectorSumTest()
        {
            IntVector testVectorA = new IntVector(1, 2);
            IntVector testVectorB = new IntVector(2, 3);

            IntVector sumVector = testVectorA + testVectorB;
            Assert.AreEqual(testVectorA.X + testVectorB.X, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(testVectorA.Y + testVectorB.Y, sumVector.Y, "Vector Y coordinate not summed correctly");
        }
        [TestMethod]
        public void VectorSubtractionTest()
        {
            IntVector testVectorA = new IntVector(1, 2);
            IntVector testVectorB = new IntVector(2, 3);

            IntVector sumVector = testVectorA - testVectorB;
            Assert.AreEqual(testVectorA.X - testVectorB.X, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(testVectorA.Y - testVectorB.Y, sumVector.Y, "Vector Y coordinate not subtracted correctly");
        }
        [TestMethod]
        public void NegativeVectorTest()
        {
            IntVector testVectorA = new IntVector(1, 2);
            IntVector testVectorB = new IntVector(2, 3);

            IntVector sumVector = testVectorA + -testVectorB;
            Assert.AreEqual(testVectorA.X - testVectorB.X, sumVector.X, "Vector X coordinate not converted correctly");
            Assert.AreEqual(testVectorA.Y - testVectorB.Y, sumVector.Y, "Vector Y coordinate not converted correctly");
        }
    }
}
