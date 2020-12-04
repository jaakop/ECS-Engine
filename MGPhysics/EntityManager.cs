using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPhysics
{
    public interface IEntityManager { }

    public class EntityManager : IEntityManager
    {
        private int key;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntityManager()
        {
            key = 0;
        }

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <returns>New entity</returns>
        public Entity CreateEntity()
        {
            return new Entity(key++);
        }
    }
}
