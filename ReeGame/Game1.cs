using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MGPhysics;
using MGPhysics.Components;
using MGPhysics.Systems;

namespace ReeGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int key;

        Entity palikka1;

        Dictionary<int, Sprite> sprites;
        Dictionary<int, IntVector> positions;
        Dictionary<int, IntVector> sizes;

        int movementSpeed;

        Camera2D camera;

        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            key = 0;
            movementSpeed = 5;

            camera = new Camera2D(new IntVector(0, 0), 0.5f);

            sprites = new Dictionary<int, Sprite>();
            positions = new Dictionary<int, IntVector>();
            sizes = new Dictionary<int, IntVector>();
            // TODO: Add your initialization logic here
            palikka1 = CreateNewEntity();
            CreatePalikka(palikka1, new IntVector(100, 100), new IntVector(424, 0));
            Entity palikka = CreateNewEntity();
            CreatePalikka(palikka, new IntVector(100,100), new IntVector(300, 100));
            palikka = CreateNewEntity();
            CreatePalikka(palikka, new IntVector(100,100), new IntVector(50, 200));
            palikka = CreateNewEntity();
            CreatePalikka(palikka, new IntVector(100,50), new IntVector(400, 120));

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

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            int deltaTime = gameTime.ElapsedGameTime.Milliseconds / 10;
            IntVector velocity = new IntVector(0, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                velocity += new IntVector(0, -movementSpeed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                velocity += new IntVector(0, movementSpeed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                velocity += new IntVector(-movementSpeed,0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity += new IntVector(movementSpeed,0);
            }
            PhysicsSystem.MoveEntity(palikka1.Key, velocity * deltaTime, ref positions, sizes);

            camera.Position = positions[palikka1.Key];
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetTransformationMatrix(GraphicsDevice.Viewport));
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            RenderSystem.RenderSprites(sprites, positions, sizes, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        Entity CreateNewEntity()
        {
            Entity entity = new Entity(key);
            key++;
            return entity;
        }

        void CreatePalikka(Entity palikka, IntVector size, IntVector posisition)
        {
            Texture2D basicTexture = new Texture2D(GraphicsDevice, 1, 1);
            basicTexture.SetData(new Color[] { Color.White });
            sprites.Add(palikka.Key, new Sprite(basicTexture, Color.White));

            positions.Add(palikka.Key, posisition);

            sizes.Add(palikka.Key, size);
        }
    }
}
