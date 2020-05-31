using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MGPhysics;
using MGPhysics.Components;

namespace ReeGame.Components
{
    public struct GroupComponent : IComponent
    {
        public Entity LeaderEntity { get; set; }
        public List<Entity> members { get; set; }

        public GroupComponent(Entity leaderEntity)
        {
            LeaderEntity = leaderEntity;
            members = new List<Entity>();
        }

        /// <summary>
        /// Check if entity is a member or leader
        /// </summary>
        /// <param name="entity">Entity to check</param>
        /// <returns></returns>
        public bool ContainsEntity(Entity entity)
        {
            if (LeaderEntity == entity)
                return true;

            return members.Contains(entity);
        }

        /// <summary>
        /// Removes entity from groups members
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        public void RemoveMember(Entity entity)
        {
            for(int i = 0; i < members.Count; i++)
            {
                if (members[i] == entity)
                    members.RemoveAt(i);
            }
        }
    }
}
