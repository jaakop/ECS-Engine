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
        public int Key { get; }
    }
}
