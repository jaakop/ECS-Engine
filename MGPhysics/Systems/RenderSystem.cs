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
        public static void RenderSprites(Dictionary<int, Sprite> sprites, Dictionary<int, Vector> positions, Dictionary<int, Vector> sizes, SpriteBatch spriteBatch)
        {
            foreach(KeyValuePair<int, Sprite> sprite in sprites)
            {
                Vector position = new Vector(0, 0);
                Vector size = new Vector(sprite.Value.Texture.Width, sprite.Value.Texture.Height);

                if (positions.ContainsKey(sprite.Key))
                    position = positions[sprite.Key];
                if (sizes.ContainsKey(sprite.Key))
                    size = sizes[sprite.Key];

                spriteBatch.Draw(sprite.Value.Texture, new Rectangle(position.IntegerX - size.IntegerX/2, position.IntegerY - size.IntegerY / 2, size.IntegerX, size.IntegerY), sprite.Value.ColorMask);
            }
        }
    }
}
