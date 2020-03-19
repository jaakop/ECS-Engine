using MGPhysics.Components;
using System;
using System.Collections.Generic;
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
        /// <returns>A list of the entities, that were collided with</returns>
        public static List<int> MoveEntity(int entityKey, IntVector velocity, ref Dictionary<int, IntVector> positions, Dictionary<int, IntVector> hitBoxes)
        {
            IntVector position = positions[entityKey];
            IntVector hitbox = hitBoxes[entityKey];
            IntVector adjustedPosition = positions[entityKey] + velocity;

            List<int> collidedWith = new List<int>();

            foreach (KeyValuePair<int, IntVector> entity in positions)
            {
                if (entity.Key == entityKey)
                    continue;

                if (!hitBoxes.ContainsKey(entity.Key))
                    continue;

                IntVector entityPosition = entity.Value;
                IntVector entityHitBox = hitBoxes[entity.Key];

                if (entityPosition.X + entityHitBox.X / 2 > adjustedPosition.X - hitbox.X / 2
                    && entityPosition.X - entityHitBox.X / 2 < adjustedPosition.X + hitbox.X / 2
                    && entityPosition.Y + entityHitBox.Y / 2 > adjustedPosition.Y - hitbox.Y / 2
                    && entityPosition.Y - entityHitBox.Y / 2 < adjustedPosition.Y + hitbox.Y / 2)
                {
                    collidedWith.Add(entity.Key);

                    int distX = Math.Abs(position.X - entityPosition.X) - entityHitBox.X / 2;
                    int distY = Math.Abs(position.Y - entityPosition.Y) - entityHitBox.Y / 2;

                    if (distX >= distY)
                    {
                        if (velocity.X > 0)
                            adjustedPosition.X = entityPosition.X - entityHitBox.X / 2 - hitbox.X / 2;
                        else
                            adjustedPosition.X = entityPosition.X + entityHitBox.X / 2 + hitbox.X / 2;
                    }

                    if (distX <= distY)
                    {
                        if (velocity.Y > 0)
                            adjustedPosition.Y = entityPosition.Y - entityHitBox.Y / 2 - hitbox.Y / 2;
                        else
                            adjustedPosition.Y = entityPosition.Y + entityHitBox.Y / 2 + hitbox.Y / 2;
                    }
                }
            }
            positions[entityKey] = adjustedPosition;
            return collidedWith;
        }
    }
}
