using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGPhysics.Components
{
    public struct Sprite : IComponent
    {
        /// <summary>
        /// New sprite object
        /// </summary>
        /// <param name="texture">Texture of the sprite</param>
        /// <param name="color">Color mask of the sprite</param>
        public Sprite(Texture2D texture, Color color)
        {
            Texture = texture;
            ColorMask = color;
        }

        public Texture2D Texture{ get; }
        public Color ColorMask { get; }
    }
}
