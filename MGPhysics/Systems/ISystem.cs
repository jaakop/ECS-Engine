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
        /// <summary>
        /// Entity assigned to this system
        /// </summary>
        Entity AssignedEntity
        {
            get;
        }

        /// <summary>
        /// Method to be called every frame
        /// </summary>
        /// <param name="manager">Component manager to access components</param>
        /// <param name="deltaTime">Time passed between previous and this frame</param>
        void Call(ComponentManager manager, int deltaTime);
    }
}
