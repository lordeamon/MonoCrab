﻿using System.Collections.Generic;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MonoCrab
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public float deltaTime;
        public Camera2D gameCamera;
        private static GameWorld GM;
        public Rectangle displayRectangle;
        private Texture2D background;
        public static GameWorld gameWorld
        {
            get
            {
                if (GM == null)
                {
                    GM = new GameWorld();
                }
                return GM;
            }
        }
        private static List<CCollider> colliders = new List<CCollider>();
        internal List<CCollider> Colliders
        {
            get { return colliders; }
            set { colliders = value; }
        }
        List<GameObject> gameObjects = new List<GameObject>();
        

        internal List<GameObject> GameObjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }
        List<GameObject> baitlist = new List<GameObject>();


        internal List<GameObject> BaitList
        {
            get { return baitlist; }
            set { baitlist = value; }
        }

        /// <summary>
        /// Private constructor because of singleton patteren
        /// </summary>
        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

        }
        /// <summary>
        /// Allows adding in new GameObjects at start
        /// </summary>
        private void AddGameObjects()
        {
            GameObject crab = new GameObject(new Vector2(100,100));
            crab.AddComponent(new CSpriteRenderer(crab,"crab",Color.White,1f));
            crab.AddComponent(new CAnimator(crab));
            crab.AddComponent(new CCollider(crab,true));
            crab.AddComponent(new CCrab(crab));
            gameObjects.Add(crab);

            //GameObject newcrab = new GameObject(new Vector2(300, 300));
            //newcrab.AddComponent(new CSpriteRenderer(newcrab, "crap", Color.White, 1f));
            //newcrab.AddComponent(new CAnimator(newcrab));
            //newcrab.AddComponent(new CCrab(newcrab));
            //gameObjects.Add(newcrab);

            GameObject bait = new GameObject(new Vector2(700,360));
            bait.AddComponent(new CSpriteRenderer(bait,"NegBait1",Color.White,1f));
            bait.AddComponent(new CAnimator(bait));
            bait.AddComponent(new CBait(bait, 1));
            bait.AddComponent(new CCollider(bait,true));
            gameObjects.Add(bait);
            baitlist.Add(bait);

            GameObject newbait = new GameObject(new Vector2(400, 100));
            newbait.AddComponent(new CSpriteRenderer(newbait, "NegBait5", Color.White, 1f));
            newbait.AddComponent(new CAnimator(newbait));
            newbait.AddComponent(new CBait(newbait, -5));
            newbait.AddComponent(new CCollider(newbait, true));
            gameObjects.Add(newbait);
            baitlist.Add(newbait);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            displayRectangle = GraphicsDevice.Viewport.Bounds;
            AddGameObjects();
           //this.IsMouseVisible = true;
            //Initialize the camera
            gameCamera = new Camera2D(graphics.GraphicsDevice.Viewport.Bounds);
            //this.graphics.ToggleFullScreen();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //AddGameObjects();
            // TODO: use this.Content to load your game content here
            foreach (GameObject go in GameObjects)
            {
                if (go != null)
                {
                    go.LoadContent(this.Content);
                }
            }
            background = Content.Load<Texture2D>("MonoCrabBackground");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (GameObject go in GameObjects)
            {
                go.Update();
                
            }
            //Update our camera
            gameCamera.Update();
            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, gameCamera.viewMatrix);


            spriteBatch.Draw(background,Vector2.Zero, displayRectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);


            foreach (GameObject go in GameObjects)
            {
                go.Draw(spriteBatch);
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
