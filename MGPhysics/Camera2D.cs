using MGPhysics.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGPhysics
{
    public class Camera2D
    {
        IntVector position;
        float zoom;

        public Camera2D(IntVector Position, float Zoom)
        {
            this.position = Position;
            this.zoom = Zoom;
        }
        
        public Matrix GetTransformationMatrix(Viewport viewport)
        {
            return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                         Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
        }

        public IntVector Position { get => position; set => position = value; }
        public float Zoom { get => zoom; set => zoom = value; }
    }
}
