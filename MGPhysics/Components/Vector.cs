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
         
        /// <summary>
        /// Get normalized <code>Vector</code> from an angle
        /// </summary>
        /// <param name="angle">Angle as degrees</param>
        /// <returns>Normalized <code>Vector</code></returns>
        public static Vector GetVectorFromAngle(float angle)
        {
            return new Vector((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        /// <summary>
        /// Gets angle of vector in degrees
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <returns></returns>
        public static float GetAngleFromVector(Vector vector)
        {
            return (float)Math.Tanh(vector.Y / vector.X);
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

        /// <summary>
        /// Interpolates two vector by t
        /// </summary>
        /// <param name="start">Starting point</param>
        /// <param name="end">End point</param>
        /// <param name="t">The interpolant</param>
        /// <returns></returns>
        public static Vector Lerp(Vector start, Vector end, float t)
        {
            return start + (end - start) * t;
        }

        /// <summary>
        /// Make a unit vector
        /// </summary>
        /// <returns>A unit vector</returns>
        public Vector Normalize()
        {
            float lenght = (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return new Vector(X / lenght, Y / lenght);
        }
    }
}
