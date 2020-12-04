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
        /// <summary>
        /// Constructor
        /// </summary>
        public ECSManager()
        {
            this.ComponentManager = new ComponentManager();
            this.SystemManager = new SystemManager();
            this.EntityManager = new EntityManager();
        }

        /// <summary>
        /// Component manager
        /// </summary>
        public ComponentManager ComponentManager {
            get;
        }

        /// <summary>
        /// System manager
        /// </summary>
        public SystemManager SystemManager
        {
            get;
        }

        /// <summary>
        /// Entity manager
        /// </summary>
        public EntityManager EntityManager
        {
            get;
        }
    }
}
