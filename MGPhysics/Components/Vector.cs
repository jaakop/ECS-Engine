using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics.Components
{
    public struct Vector : IComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
         
        //Operators
        /// <summary>
        /// Adds two Vector together
        /// </summary>
        /// <param name="a">Base vector</param>
        /// <param name="b">Vector to add</param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X+b.X, a.Y+b.Y);
        }

        /// <summary>
        /// Adds an float to Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">floaterger to add to the vector</param>
        /// <returns></returns>
        public static Vector operator +(Vector a, float b)
        {
            return new Vector(a.X + b, a.Y + b);
        }

        /// <summary>
        /// Increase vector by one
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static Vector operator ++(Vector a)
        {
            return new Vector(a.X + 1, a.Y + 1);
        }

        /// <summary>
        /// Flips the vector
        /// </summary>
        /// <param name="vector">Base Vector</param>
        /// <returns></returns>
        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y);
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">Vector to substract</param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y-b.Y);
        }

        /// <summary>
        /// Subtracts a float from a vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">float to substract from the vector</param>
        /// <returns></returns>
        public static Vector operator -(Vector a, float b)
        {
            return new Vector(a.X - b, a.Y - b);
        }

        /// <summary>
        /// Decrease vector by one
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static Vector operator --(Vector a)
        {
            return new Vector(a.X - 1, a.Y - 1);
        }

        /// <summary>
        /// Divide Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static Vector operator /(Vector a, float b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

        /// <summary>
        /// Multiply Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        /// <summary>
        /// Return the X value as rounded integer
        /// </summary>
        public int IntegerX
        {
            get
            {
                return (int)Math.Round(X);
            }
        }

        /// <summary>
        /// Return the Y value as rounded integer
        /// </summary>
        public int IntegerY
        {
            get
            {
            return (int)Math.Round(Y);
            }
        }

        public static Vector Lerp(Vector start, Vector end, float t)
        {
            return start + (end - start) * t;
        }
    }
}
