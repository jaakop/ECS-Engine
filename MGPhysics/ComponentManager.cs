using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics.Components;

namespace MGPhysics
{
    public interface IComponentManager
    {

    }
    public class ComponentManager : IComponentManager
    {
        private List<IComponentArray> componenArrays;
        private Dictionary<Type, int> typeIndexArray;
        private int arrayIndex;

        public ComponentManager()
        {
            arrayIndex = 0;
            typeIndexArray = new Dictionary<Type, int>();
            componenArrays = new List<IComponentArray>();
        }

        public void RegisterComponent<T>() where T : IComponent
        {
            typeIndexArray.Add(typeof(T), arrayIndex);
            componenArrays.Add(new ComponentArray<T>());
            arrayIndex++;
        }

        public ComponentArray<T> GetComponentArray<T>() where T : IComponent
        {
            if (typeIndexArray.ContainsKey(typeof(T))) throw new Exception("Compnent is not registered");

            return (ComponentArray<T>)componenArrays[typeIndexArray[typeof(T)]];
        }

        public T GetComponent<T>(Entity entity) where T : IComponent
        {
            ComponentArray<T> array = GetComponentArray<T>();

            if (!array.Array.ContainsKey(entity)) throw new IndexOutOfRangeException("This entity does not have this component");

            return GetComponentArray<T>().Array[entity];
        }
    }
    public struct ComponentArray<T> : IComponentArray where T : IComponent
    {
        public Dictionary<Entity, T> Array { get; }
    }
    public interface IComponentArray
    {
    }
}
