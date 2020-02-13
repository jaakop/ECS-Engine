using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics.Components
{
    public struct IntVector : Component
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector(int x, int y)
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
        public static IntVector operator +(IntVector a, IntVector b)
        {
            return new IntVector(a.X+b.X, a.Y+b.Y);
        }
        /// <summary>
        /// Adds an int to Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">Interger to add to the vector</param>
        /// <returns></returns>
        public static IntVector operator +(IntVector a, int b)
        {
            return new IntVector(a.X + b, a.Y + b);
        }
        /// <summary>
        /// Increase vector by one
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static IntVector operator ++(IntVector a)
        {
            return new IntVector(a.X + 1, a.Y + 1);
        }
        /// <summary>
        /// Flips the vector
        /// </summary>
        /// <param name="vector">Base Vector</param>
        /// <returns></returns>
        public static IntVector operator -(IntVector vector)
        {
            return new IntVector(-vector.X, -vector.Y);
        }
        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">Vector to substract</param>
        /// <returns></returns>
        public static IntVector operator -(IntVector a, IntVector b)
        {
            return new IntVector(a.X - b.X, a.Y-b.Y);
        }
        /// <summary>
        /// Subtracts a int from a vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <param name="b">Int to substract from the vector</param>
        /// <returns></returns>
        public static IntVector operator -(IntVector a, int b)
        {
            return new IntVector(a.X - b, a.Y - b);
        }
        /// <summary>
        /// Decrease vector by one
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static IntVector operator --(IntVector a)
        {
            return new IntVector(a.X - 1, a.Y - 1);
        }
        /// <summary>
        /// Divide Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static IntVector operator /(IntVector a, int b)
        {
            return new IntVector(a.X / b, a.Y / b);
        }
        /// <summary>
        /// Multiply Vector
        /// </summary>
        /// <param name="a">Base Vector</param>
        /// <returns></returns>
        public static IntVector operator *(IntVector a, int b)
        {
            return new IntVector(a.X * b, a.Y * b);
        }
    }
}
