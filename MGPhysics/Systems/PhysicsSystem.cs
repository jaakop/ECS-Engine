using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGPhysics.Components;
namespace MGPhysics.Systems
{
    public static class PhysicsSystem
    {
        /// <summary>
        /// Moves an object and checks for collission on it
        /// </summary>
        /// <param name="entityKey">The entity to move</param>
        /// <param name="positions">Dictionary on entity positions</param>
        /// <param name="hitBoxes">Dictionary on entity hit boxes</param>
        /// <param name="velocity">Velocity of the entity</param>
        public static void MoveEntity(int entityKey, IntVector velocity, ref Dictionary<int, IntVector> positions, Dictionary<int, IntVector> hitBoxes)
        {
            IntVector amountMoved = velocity;
            IntVector adjustedPosition = positions[entityKey] + amountMoved;
            foreach (KeyValuePair<int, IntVector> entity in positions)
            {
                //Check if the entity is the same as the entity that is being moved
                if (entity.Key == entityKey)
                    continue;
                
                //Check if entity has an hitbox
                if (!hitBoxes.ContainsKey(entity.Key))
                    continue;

                //Check if entity collides with moved entity
                if(entity.Value.X + hitBoxes[entity.Key].X / 2 > adjustedPosition.X - hitBoxes[entityKey].X / 2
                    && entity.Value.X - hitBoxes[entity.Key].X / 2 < adjustedPosition.X + hitBoxes[entityKey].X / 2)
                {
                    if(entity.Value.Y + hitBoxes[entity.Key].Y / 2 > adjustedPosition.Y - hitBoxes[entityKey].Y / 2
                    && entity.Value.Y - hitBoxes[entity.Key].Y / 2 < adjustedPosition.Y + hitBoxes[entityKey].Y / 2)
                    {
                        //Check if the collission hapens from the sides (left & right)
                        if (Math.Abs(Math.Abs(positions[entityKey].X) - Math.Abs(entity.Value.X)) - hitBoxes[entity.Key].X/2
                            >
                            Math.Abs(Math.Abs(positions[entityKey].Y) - Math.Abs(entity.Value.Y)) - hitBoxes[entity.Key].Y / 2)
                        {
                            //Move the moved entity back on the X axis
                            if(velocity.X > 0)
                            {
                                adjustedPosition.X = entity.Value.X - hitBoxes[entity.Key].X / 2 - hitBoxes[entityKey].X / 2;
                            }
                            else
                            {
                                adjustedPosition.X = entity.Value.X + hitBoxes[entity.Key].X / 2 + hitBoxes[entityKey].X / 2;
                            }
                        }

                        //Check if the collission happens from top or bottom
                        if (Math.Abs(Math.Abs(positions[entityKey].X) - Math.Abs(entity.Value.X)) - hitBoxes[entity.Key].X / 2
                            <
                            Math.Abs(Math.Abs(positions[entityKey].Y) - Math.Abs(entity.Value.Y)) - hitBoxes[entity.Key].Y / 2)
                        {
                            //Move the moved entity back on the Y axis
                            if (velocity.Y > 0)
                            {
                                adjustedPosition.Y = entity.Value.Y - hitBoxes[entity.Key].Y / 2 - hitBoxes[entityKey].Y / 2;
                            }
                            else
                            {
                                adjustedPosition.Y = entity.Value.Y + hitBoxes[entity.Key].Y / 2 + hitBoxes[entityKey].Y / 2;
                            }
                        }
                    }
                }
            }
            positions[entityKey] = adjustedPosition;
        }
    }
}
