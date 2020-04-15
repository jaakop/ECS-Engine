using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics.Components
{
    public struct RigidBody : IComponent
    {
        public Vector HitBox { get; set; }

        public RigidBody(Vector hitBox)
        {
            HitBox = hitBox;
        }
    }
}
