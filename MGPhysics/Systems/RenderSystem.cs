using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MGPhysics.Components;

namespace MGPhysics.Systems
{
    public static class RenderSystem
    {
        /// <summary>
        /// Draws sprites on to screen
        /// </summary>
        /// <param name="sprites">Dictionary of sprites to draw</param>
        /// <param name="positions">Dictionary of positions to draw the sprites to</param>
        /// <param name="sizes">Dictionary of sizes for the sprites</param>
        /// <param name="spriteBatch">Spritebatch to draw with</param>
        public static void RenderSprites(Dictionary<Entity, Sprite> sprites, Dictionary<Entity, Transform> transfroms, SpriteBatch spriteBatch)
        {
            foreach(KeyValuePair<Entity, Sprite> sprite in sprites)
            {
                if (!transfroms.ContainsKey(sprite.Key))
                    continue;

                Transform transform = transfroms[sprite.Key];

                spriteBatch.Draw(sprite.Value.Texture, 
                                 new Rectangle(transform.Position.IntegerX - transform.Size.IntegerX/2, transform.Position.IntegerY - transform.Size.IntegerY / 2, 
                                                transform.Size.IntegerX, transform.Size.IntegerY), 
                                 sprite.Value.ColorMask);
            }
        }
    }
}
