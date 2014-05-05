using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using AluminumBall.ECS;
using AluminumBall.Components;

namespace AluminumBall
{
    public class Gameplay : Game
    {
        private GraphicsDeviceManager Graphics { get; set; }
        private SpriteBatch SpriteBatch { get; set; }

        private GameState GameState { get; set; }

        public Gameplay()
            : base()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            GameState = new GameState();
        }

        protected override void Initialize()
        {
            base.Initialize();

            GameState.AddEntity(new Entity()
                .AddComponent(new Position(10f, 400f))
                .AddComponent(new Renderable("circle"))
                .AddComponent(new Velocity(0.3f, -0.7f))
                .AddComponent(new Gravity(0.0098f))
            );

            ECSManager.InitClientAPI();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            ECSManager.Textures.Add("circle", Content.Load<Texture2D>("circle"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var entities = new List<Entity>();

            foreach (var system in ECSManager.LogicSystems)
            {
                entities = system.Query(GameState.Entities);

                foreach (var entity in entities)
                {
                    system.Update(entity, gameTime);
                }
            }

            ECSManager.Run(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ECSManager.GetClearColor());

            var entities = new List<Entity>();

            foreach (var system in ECSManager.GraphicSystems)
            {
                entities = system.Query(GameState.Entities);

                foreach (var entity in entities)
                {
                    system.Draw(entity, SpriteBatch);
                }
            }

            base.Draw(gameTime);
        }
    }
}
