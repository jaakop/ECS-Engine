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

        Dictionary<Entity, Transform> transfroms;
        Dictionary<Entity, RigidBody> rigidBodies;
        Dictionary<Entity, Sprite> sprites;

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
            Entity.InitializeKeyIndex();

            IsMouseVisible = true;
            movementSpeed = 7;
            mousePressed = false;

            camera = new Camera2D(new Vector(0, 0), 0.5f);

            transfroms = new Dictionary<Entity, Transform>();
            rigidBodies = new Dictionary<Entity, RigidBody>();
            sprites = new Dictionary<Entity, Sprite>();

            targetPalikka = Entity.NewEntity();
            // TODO: Add your initialization logic here
            palikka1 = Entity.NewEntity();
            CreatePalikka(palikka1, new Vector(100, 100), new Vector(150, -50));
            Entity palikka = Entity.NewEntity();
            CreatePalikka(palikka, new Vector(100, 100), new Vector(300, 100));
            palikka = Entity.NewEntity();
            CreatePalikka(palikka, new Vector(100, 100), new Vector(50, 450));
            palikka = Entity.NewEntity();
            CreatePalikka(palikka, new Vector(100, 50), new Vector(-100, -100));

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
                    CreatePalikka(targetPalikka, new Vector(25, 25), new Vector((int)mousePosition.X, (int)mousePosition.Y));
                    mousePressed = true;
                }
            }
            else if(mouseState.LeftButton == ButtonState.Released)
            {
                mousePressed = false;   
            }

            Vector velocity = new Vector(0,0);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity += new Vector(0, -1 * movementSpeed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity += new Vector(0, 1 * movementSpeed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity += new Vector(-1 * movementSpeed,0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity += new Vector(1 * movementSpeed, 0);
            }

            PhysicsSystem.MoveEntity(palikka1, velocity, ref transfroms, rigidBodies);

            camera.Position = transfroms[palikka1].Position;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetTransformationMatrix(GraphicsDevice.Viewport));
            RenderSystem.RenderSprites(sprites, transfroms, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void CreatePalikka(Entity palikka, Vector size, Vector position)
        {
            Texture2D basicTexture = new Texture2D(GraphicsDevice, 1, 1);
            basicTexture.SetData(new Color[] { Color.White });

            //Add sprite
            if (!sprites.ContainsKey(palikka))
            {
                sprites.Add(palikka, new Sprite(basicTexture, Color.White));
            }
            else
            {
                sprites[palikka] = new Sprite(basicTexture, Color.White);
            }

            //Add transform
            if (!transfroms.ContainsKey(palikka))
            {
                transfroms.Add(palikka, new Transform(position, size));
            }
            else
            {
                transfroms[palikka] = new Transform(position, size);
            }

            //Add rigidbody
            if (!rigidBodies.ContainsKey(palikka))
            {
                rigidBodies.Add(palikka, new RigidBody(size));
            }
            else
            {
                rigidBodies[palikka] = new RigidBody(size);
            }
        }
    }
}
