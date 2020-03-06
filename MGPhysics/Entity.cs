using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics
{
    public struct Entity
    {
        private static int keyIndex;

        private Entity(int key)
        {
            Key = key;
        }

        public static Entity NewEntity()
        {
            keyIndex++;
            return new Entity(keyIndex - 1);
        }

        public static void InitializeKeyIndex()
        {
            keyIndex = 0;
        }

        public static void InitializeKeyIndex(int newKeyIndex)
        {
            keyIndex = newKeyIndex;
        }

        public int Key { get; }
    }
}
