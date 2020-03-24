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
        public static List<int> MoveEntity(int entityKey, Vector velocity, ref Dictionary<int, Vector> positions, Dictionary<int, Vector> hitBoxes)
        {
            Vector position = positions[entityKey];
            Vector hitbox = hitBoxes[entityKey];
            Vector adjustedPosition = positions[entityKey] + velocity;

            List<int> collidedEntities = new List<int>();

            foreach (KeyValuePair<int, Vector> entity in positions)
            {
                if (entity.Key == entityKey)
                    continue;

                if (!hitBoxes.ContainsKey(entity.Key))
                    continue;

                Vector entityPosition = entity.Value;
                Vector entityHitBox = hitBoxes[entity.Key];

                if (CheckCollissions(adjustedPosition, hitbox, entityPosition, entityHitBox))
                {
                    collidedEntities.Add(entity.Key);

                    int distX = (int)Math.Round(Math.Abs(position.X - entityPosition.X) - entityHitBox.X / 2);
                    int distY = (int)Math.Round(Math.Abs(position.Y - entityPosition.Y) - entityHitBox.Y / 2);

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
            return collidedEntities;
        }

        /// <summary>
        /// Checks for all collissions for an object
        /// </summary>
        /// <param name="entityKey">Entity key of the collider</param>
        /// <param name="positions">Dictionary of positions</param>
        /// <param name="hitBoxes">Dictionary of hitboxes</param>
        /// <returns>List of the collided entities</returns>
        public static List<int> CheckCollissions(int entityKey, Dictionary<int, Vector> positions, Dictionary<int, Vector> hitBoxes)
        {
            List<int> collidedEntities = new List<int>();

            Vector position = positions[entityKey];
            Vector hitbox = hitBoxes[entityKey];

            foreach (KeyValuePair<int, Vector> entity in positions)
            {
                if (entity.Key == entityKey)
                    continue;

                if (!hitBoxes.ContainsKey(entity.Key))
                    continue;

                Vector entityPosition = entity.Value;
                Vector entityHitBox = hitBoxes[entity.Key];

                if (entityPosition.X + entityHitBox.X / 2 > position.X - hitbox.X / 2
                    && entityPosition.X - entityHitBox.X / 2 < position.X + hitbox.X / 2
                    && entityPosition.Y + entityHitBox.Y / 2 > position.Y - hitbox.Y / 2
                    && entityPosition.Y - entityHitBox.Y / 2 < position.Y + hitbox.Y / 2)
                {
                    collidedEntities.Add(entity.Key);
                }
            }

            return collidedEntities;
        }

        /// <summary>
        /// Check for collission between two objects
        /// </summary>
        /// <param name="colliderKey">Kay of the collider</param>
        /// <param name="targetKey">Key of the collission target</param>
        /// <param name="positions">Dictionary of positions</param>
        /// <param name="hitBoxes">Dictionary of hitboxes</param>
        /// <returns></returns>
        public static bool CheckCollissions(int colliderKey, int targetKey, Dictionary<int, Vector> positions, Dictionary<int, Vector> hitBoxes)
        {
            Vector colliderPosition = positions[colliderKey];
            Vector targetPosition = positions[targetKey];

            Vector colliderHitBox = hitBoxes[colliderKey];
            Vector targetHitBox = hitBoxes[targetKey];

            if (targetPosition.X + targetHitBox.X / 2 > colliderPosition.X - colliderHitBox.X / 2
                && targetPosition.X - targetHitBox.X / 2 < colliderPosition.X + colliderHitBox.X / 2
                && targetPosition.Y + targetHitBox.Y / 2 > colliderPosition.Y - colliderHitBox.Y / 2
                && targetPosition.Y - targetHitBox.Y / 2 < colliderPosition.Y + colliderHitBox.Y / 2)
                    return true;

            return false;
        }

        /// <summary>
        /// Check for collission between two objects
        /// </summary>
        /// <param name="colliderPosition">Position of collider</param>
        /// <param name="colliderHitBox">HitBox of the collider</param>
        /// <param name="targetPosition">Position of the target</param>
        /// <param name="targetHitBox">HitBox of the target</param>
        /// <returns></returns>
        public static bool CheckCollissions(Vector colliderPosition, Vector colliderHitBox, Vector targetPosition, Vector targetHitBox)
        {
            if (targetPosition.X + targetHitBox.X / 2 > colliderPosition.X - colliderHitBox.X / 2
                && targetPosition.X - targetHitBox.X / 2 < colliderPosition.X + colliderHitBox.X / 2
                && targetPosition.Y + targetHitBox.Y / 2 > colliderPosition.Y - colliderHitBox.Y / 2
                && targetPosition.Y - targetHitBox.Y / 2 < colliderPosition.Y + colliderHitBox.Y / 2)
                return true;

            return false;
        }
    }
}
