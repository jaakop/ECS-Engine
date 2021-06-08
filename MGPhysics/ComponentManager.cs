using System;
using System.Collections.Generic;

namespace MGPhysics
{
    public interface IComponentManager
    {

    }
    public interface IComponentArray
    {
        /// <summary>
        /// Removes all components of an entity from component arrays
        /// </summary>
        /// <param name="entity"></param>
        void EntityDestroyed(Entity entity);
    }

    public class ComponentManager : IComponentManager
    {
        private List<IComponentArray> componentArrays;
        private Dictionary<Type, int> typeIndexArray;

        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentManager()
        {
            typeIndexArray = new Dictionary<Type, int>();
            componentArrays = new List<IComponentArray>();
        }

        /// <summary>
        /// Registers a comopnent to the manager
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        public void RegisterComponent<T>() where T : IComponent
        {
            typeIndexArray.Add(typeof(T), componentArrays.Count);
            componentArrays.Add(new ComponentArray<T>());
        }

        /// <summary>
        /// Gets component array of a certain type
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component array</returns>
        public ComponentArray<T> GetComponentArray<T>() where T : IComponent
        {
            if (!typeIndexArray.ContainsKey(typeof(T))) throw new KeyNotFoundException("Component is not registered");

            return (ComponentArray<T>)componentArrays[typeIndexArray[typeof(T)]];
        }

        /// <summary>
        /// Gets component of an entity
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Component</returns>
        public T GetComponent<T>(Entity entity) where T : IComponent
        {
            ComponentArray<T> array = GetComponentArray<T>();

            if (!array.Array.ContainsKey(entity)) throw new IndexOutOfRangeException("This entity does not have this component");

            return GetComponentArray<T>().Array[entity];
        }

        /// <summary>
        /// Gets all entities with a certain component
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <returns>List of entities with that component</returns>
        public List<Entity> GetEntitiesWithComponent<T>() where T : IComponent
        {
            List<Entity> entities = new List<Entity>();
            foreach(KeyValuePair<Entity, T> entry in GetComponentArray<T>().Array)
            {
                entities.Add(entry.Key);
            }
            return entities;
        }

        /// <summary>
        /// Replaces a component in an array
        /// </summary>
        /// <typeparam name="T">Component</typeparam>
        /// <param name="entity">Entity to wich the component belongs to</param>
        /// <param name="replacer">Component to be replace existing one</param>
        public void UpdateComponent<T>(Entity entity, T replacer) where T : IComponent
        {
            GetComponentArray<T>().Array[entity] = replacer;
        }

        /// <summary>
        /// Removes all components of an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void EntityDestroyed(Entity entity)
        {
            foreach(KeyValuePair<Type, int> entries in typeIndexArray)
            {
                componentArrays[entries.Value].EntityDestroyed(entity);
            }
        }
    }

    public class ComponentArray<T> : IComponentArray where T : IComponent
    {
        public ComponentArray()
        {
            Array = new Dictionary<Entity, T>();
        }

        public Dictionary<Entity, T> Array { get; }

        /// <summary>
        /// Removes all components of an entity from component arrays
        /// </summary>
        /// <param name="entity"></param>
        void IComponentArray.EntityDestroyed(Entity entity)
        {
            Array.Remove(entity);
        }
    }
}
