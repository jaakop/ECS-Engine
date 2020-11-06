using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics;

namespace MGPhysics.Systems
{
    public interface ISystem
    {
        Entity AssignedEntity
        {
            get;
        }
        void Call(ComponentManager manager, int deltaTime);
    }
}
