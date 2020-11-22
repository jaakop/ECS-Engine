using System;
using MGPhysics;
using MGPhysics.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VectorTesting
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
            Vector sumVector = new Vector(1, 2) + new Vector(2, 3);
            Assert.AreEqual(3, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(5, sumVector.Y, "Vector Y coordinate not summed correctly");

            sumVector = new Vector(0, 0) + new Vector(0, 0);
            Assert.AreEqual(0, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(0, sumVector.Y, "Vector Y coordinate not summed correctly");

            sumVector = new Vector(-1, -4) + new Vector(3, 2);
            Assert.AreEqual(2, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(-2, sumVector.Y, "Vector Y coordinate not summed correctly");

            sumVector = new Vector(-3, -7) + new Vector(-1, -5);
            Assert.AreEqual(-4, sumVector.X, "Vector X coordinate not summed correctly");
            Assert.AreEqual(-12, sumVector.Y, "Vector Y coordinate not summed correctly");
        }

        [TestMethod]
        public void VectorSubtractionTest()
        {
            Vector sumVector = new Vector(1, 2) - new Vector(2, 3);
            Assert.AreEqual(-1, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(-1, sumVector.Y, "Vector Y coordinate not subtracted correctly");

            sumVector = new Vector(0, 0) - new Vector(0, 0);
            Assert.AreEqual(0, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(0, sumVector.Y, "Vector Y coordinate not subtracted correctly");

            sumVector = new Vector(-1, -4) - new Vector(3, 2);
            Assert.AreEqual(-4, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(-6, sumVector.Y, "Vector Y coordinate not subtracted correctly");

            sumVector = new Vector(-3, -7) - new Vector(-1, -5);
            Assert.AreEqual(-2, sumVector.X, "Vector X coordinate not subtracted correctly");
            Assert.AreEqual(-2, sumVector.Y, "Vector Y coordinate not subtracted correctly");
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

        [TestMethod]
        public void VectorNormalization()
        {
            Vector testVecotr = new Vector(0, 0);
            Assert.AreEqual(testVecotr, testVecotr.Normalize(), "Vector Normalization failed (0,0)");
            testVecotr = new Vector(10, 0);
            Assert.AreEqual(new Vector(1,0), testVecotr.Normalize(), "Vector Normalization failed (1,0)");
            testVecotr = new Vector(-10, 0);
            Assert.AreEqual(new Vector(-1,0), testVecotr.Normalize(), "Vector Normalization failed (-1, 0)");
            testVecotr = new Vector(0, 10);
            Assert.AreEqual(new Vector(0, 1), testVecotr.Normalize(), "Vector Normalization failed (0, 1)");
            testVecotr = new Vector(0, -10);
            Assert.AreEqual(new Vector(0, -1), testVecotr.Normalize(), "Vector Normalization failed (0, -1)");
        }

        [TestMethod]
        public void AngleFromVector()
        {
            Vector testVector = new Vector(0,0);

            Assert.AreEqual(90f, Vector.GetAngleFromVector(testVector), "Agnle 90 from vector failed (0,0)");

            testVector = new Vector(1, 0);
            Assert.AreEqual(0f, Vector.GetAngleFromVector(testVector), "Agnle 0 from vector failed (1,0)");

            testVector = new Vector(0, 1);
            Assert.AreEqual(90f, Vector.GetAngleFromVector(testVector), "Agnle 90 from vector failed (0,1)");

            testVector = new Vector(-1, 0);
            Assert.AreEqual(180f, Vector.GetAngleFromVector(testVector), "Agnle 180 from vector failed (-1,0)");

            testVector = new Vector(0, -1);
            Assert.AreEqual(270f, Vector.GetAngleFromVector(testVector), "Agnle 270 from vector failed (0,-1)");

        }

        [TestMethod]
        public void VectorFromAngle()
        {
            Vector angleVector = Vector.GetVectorFromAngle(0);
            Assert.AreEqual(new Vector(1, 0), new Vector((float)Math.Round(angleVector.X, 10), (float)Math.Round(angleVector.Y, 10)), 
                "Vector from angle 0 failed");

            angleVector = Vector.GetVectorFromAngle(90);
            Assert.AreEqual(new Vector(0, 1), new Vector((float)Math.Round(angleVector.X, 10), (float)Math.Round(angleVector.Y, 10)), 
                "Vector from angle 90 failed");

            angleVector = Vector.GetVectorFromAngle(180);
            Assert.AreEqual(new Vector(-1, 0), new Vector((float)Math.Round(angleVector.X, 10), (float)Math.Round(angleVector.Y, 10)), 
                "Vector from angle 180 failed");

            angleVector = Vector.GetVectorFromAngle(270);
            Assert.AreEqual(new Vector(0, -1).X, new Vector((float)Math.Round(angleVector.X, 10), (float)Math.Round(angleVector.Y, 10)).X, 
                "Vector from angle 270 failed");
            Assert.AreEqual(new Vector(0, -1).Y, new Vector((float)Math.Round(angleVector.X, 10), (float)Math.Round(angleVector.Y, 10)).Y, 
                "Vector from angle 270 failed");
        }
    }
}
