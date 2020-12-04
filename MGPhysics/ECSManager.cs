using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics
{
    public interface IECSManager { }

    public class ECSManager : IECSManager
    {
        private ComponentManager componentManager;
        private SystemManager systemManager;
        private EntityManager entityManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public ECSManager()
        {
            componentManager = new ComponentManager();
            systemManager = new SystemManager();
            entityManager = new EntityManager();
        }

        /// <summary>
        /// Component manager
        /// </summary>
        public ComponentManager ComponentManager {
            get
            {
                return componentManager;
            }
        }

        /// <summary>
        /// System manager
        /// </summary>
        public SystemManager SystemManager
        {
            get
            {
                return systemManager;
            }
        }

        /// <summary>
        /// Entity manager
        /// </summary>
        public EntityManager EntityManager
        {
            get
            {
                return entityManager;
            }
        }
    }
}
