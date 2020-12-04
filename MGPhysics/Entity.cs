using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics
{
    /// <summary>
    /// ECS entity
    /// </summary>
    public struct Entity
    {
        /// <summary>
        /// New Entity
        /// </summary>
        /// <param name="key">Entity key</param>
        public Entity(int key)
        {
            Key = key;
        }

        public int Key { get; }

        /// <summary>
        /// Equals operator
        /// </summary>
        /// <param name="a">First entity</param>
        /// <param name="b">Second Entity</param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (a.Key == b.Key)
                return true;
            return false;
        }

        /// <summary>
        /// Not equals operator
        /// </summary>
        /// <param name="a">First Entity</param>
        /// <param name="b">Second Entity</param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b)
        {
            if (a.Key != b.Key)
                return true;
            return false;
        }

        /// <summary>
        /// Get hash code of this entity
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Key).GetHashCode();
        }

        /// <summary>
        /// Checks if objects equals to this entity
        /// </summary>
        /// <param name="obj">Object to compera</param>
        /// <returns>True if equals</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Entity))
                return false;

            Entity o = (Entity)obj;

            if (o != this)
                return false;

            return true;
        }
    }
}
