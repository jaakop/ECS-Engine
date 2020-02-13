using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGPhysics.Components
{
    public struct Sprite : Component
    {
        public Sprite(Texture2D texture, Color color)
        {
            Texture = texture;
            ColorMask = color;
        }
        public Texture2D Texture{ get; set; }
        public Color ColorMask { get; set; }
    }
}
