using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics.Components
{
    public struct Transform : IComponent
    {
        public Vector Position { get; set; }
        public Vector Size { get; set; }

        public Transform(Vector position, Vector size)
        {
            Position = position;
            Size = size;
        }
    }
}
    