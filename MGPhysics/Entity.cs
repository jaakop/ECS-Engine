using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics
{
    public struct Entity
    {
        public Entity(int key)
        {
            Key = key;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a.Key == b.Key)
                return true;
            return false;
        }

        public static bool operator !=(Entity a, Entity b)
        {
            if (a.Key != b.Key)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Key).GetHashCode();
        }

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
