using System.Collections.Generic;

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
        public void Update(ECSManager manager, int deltaTime)
        {
            foreach(ISystem system in registeredSystems)
            {
                system.Call(manager, deltaTime);
            }
        }
    }
}
