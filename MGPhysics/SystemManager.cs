using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics.Systems;

namespace MGPhysics
{
    public interface ISystemManager {}

    public class SystemManager : ISystemManager
    {
        /// <summary>
        /// List of registered system to be excetuted on update
        /// </summary>
        private List<ISystem> registeredSystems;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        public SystemManager()
        {
            registeredSystems = new List<ISystem>();
        }

        /// <summary>
        /// Register a system for the next update
        /// </summary>
        /// <param name="system"></param>
        public void RegisterSystem(ISystem system)
        {
            registeredSystems.Add(system);
        }

        /// <summary>
        /// Excecute update on all systems and after that clear current register
        /// </summary>
        /// <param name="componentManager">Component manager for the components</param>
        /// <param name="deltaTime">Time since last update</param>
        public void Update(ComponentManager componentManager, int deltaTime)
        {
            foreach(ISystem system in registeredSystems)
            {
                system.Call(componentManager, deltaTime);
            }
            registeredSystems.Clear();
        }
    }
}
