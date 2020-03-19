using MGPhysics;
using MGPhysics.Components;
using MGPhysics.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ReeGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Entity palikka1;

        Dictionary<int, Sprite> sprites;
        Dictionary<int, IntVector> positions;
        Dictionary<int, IntVector> sizes;

        int movementSpeed;
        bool mousePressed;
        Entity targetPalikka;

        Camera2D camera;

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            movementSpeed = 7;
            mousePressed = false;

            camera = new Camera2D(new IntVector(0, 0), 0.5f);

            sprites = new Dictionary<int, Sprite>();
            positions = new Dictionary<int, IntVector>();
            sizes = new Dictionary<int, IntVector>();
            targetPalikka = Entity.NewEntity();
            // TODO: Add your initialization logic here
            palikka1 = Entity.NewEntity();
            CreatePalikka(palikka1, new IntVector(100, 100), new IntVector(150, -50));
            Entity palikka = Entity.NewEntity();
            CreatePalikka(palikka, new IntVector(100, 100), new IntVector(300, 100));
            palikka = Entity.NewEntity();
            CreatePalikka(palikka, new IntVector(100, 100), new IntVector(50, 450));
            palikka = Entity.NewEntity();
            CreatePalikka(palikka, new IntVector(100, 50), new IntVector(-100, -100));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && !mousePressed)
            {
                if (GraphicsDevice.Viewport.Bounds.Contains(mouseState.Position))
                {
                    Vector2 mousePosition = new Vector2(camera.Position.X + mouseState.Position.X / camera.Zoom - GraphicsDevice.Viewport.Width,
                                                        camera.Position.Y + mouseState.Position.Y / camera.Zoom - GraphicsDevice.Viewport.Height);
                    CreatePalikka(targetPalikka, new IntVector(25, 25), new IntVector((int)mousePosition.X, (int)mousePosition.Y));
                    mousePressed = true;
                }

            }
            else if(mouseState.LeftButton == ButtonState.Released)
            {
                mousePressed = false;   
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetTransformationMatrix(GraphicsDevice.Viewport));
            RenderSystem.RenderSprites(sprites, positions, sizes, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void CreatePalikka(Entity palikka, IntVector size, IntVector position)
        {
            Texture2D basicTexture = new Texture2D(GraphicsDevice, 1, 1);
            basicTexture.SetData(new Color[] { Color.White });
            if (!sprites.ContainsKey(palikka.Key))
            {
                sprites.Add(palikka.Key, new Sprite(basicTexture, Color.White));
            }
            else
            {
                sprites[palikka.Key] = new Sprite(basicTexture, Color.White);
            }

            if (!positions.ContainsKey(palikka.Key))
            {
                positions.Add(palikka.Key, position);
            }
            else
            {
                positions[palikka.Key] = position;
            }

            if (!sizes.ContainsKey(palikka.Key))
            {
                sizes.Add(palikka.Key, size);
            }
            else
            {
                sizes[palikka.Key] = size;
            }
        }
    }
}
