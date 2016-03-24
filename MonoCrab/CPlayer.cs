using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoCrab
{
    class CPlayer : Component, IUpdateable, ILoadable
    {
        private Vector2 origin;
        private GameObject go;
        private float minRange = 100;
        private float maxRange = 500;
        private Random rnd;
        private bool pressed;
        private float timerLimit = 0;
        private float timePassed = 0;



        public CPlayer(GameObject gameObject) : base(gameObject)
        {
            this.go = gameObject;
            origin = gameObject.Transform.position;
            rnd = new Random(DateTime.Now.Millisecond);

        }
       
        public void Update()
        {
            

            //Check if 5 seconds has elapsed
            if (timePassed > timerLimit && GameWorld.gameWorld.startGame)
            {
                MouseState mState = Mouse.GetState();
                Vector2 mPosition = new Vector2((mState.X * GameWorld.gameWorld.gameCamera.zoom) + GameWorld.gameWorld.gameCamera.Position.X , (mState.Y * GameWorld.gameWorld.gameCamera.zoom) + GameWorld.gameWorld.gameCamera.Position.Y);


                if (GameWorld.gameWorld.BaitList.Count <= 30 && mState.LeftButton == ButtonState.Pressed && !pressed)
                {
                    pressed = true;
                    BaitTypes randomBait = (BaitTypes)rnd.Next(0, Enum.GetNames(typeof(BaitTypes)).Length - 1);
                    GameWorld.gameWorld.Add(BaitPool.baitPoolInstance.Create(mPosition, randomBait));
                   
                    //Reset your counter
                    timePassed = 0;
                    
                }
                pressed = false;
            }
            
            timePassed += (float)GameWorld.gameWorld.deltaTime;
            //Update the enemy creation timer
            
        }

        
        public Vector2 ChoosePosition()
        {

            int quadrant = rnd.Next(16);

            if (quadrant < 4)
            {
                //Top-Left Quadrant
                Vector2 topLeft = new Vector2((origin.X - rnd.Next((int)minRange, (int)maxRange)), (origin.Y - rnd.Next((int)minRange, (int)maxRange)));
                return topLeft;
            }

            else if (quadrant > 4 && quadrant < 8)
            {
                //Top-Right Quadrant
                Vector2 topRight = new Vector2((origin.X + rnd.Next((int)minRange, (int)maxRange)), (origin.Y - rnd.Next((int)minRange, (int)maxRange)));
                return topRight;
            }

            else if (quadrant > 8 && quadrant < 12)
            {
                //Lower-Right Quadrant
                Vector2 lowerRight = new Vector2((origin.X + rnd.Next((int)minRange, (int)maxRange)), (origin.Y + rnd.Next((int)minRange, (int)maxRange)));
                return lowerRight;
            }

            else if (quadrant > 12 && quadrant < 16)
            {
                //Lower-Left Quadrant
                Vector2 lowerLeft = new Vector2((origin.X - rnd.Next((int)minRange, (int)maxRange)), (origin.Y + rnd.Next((int)minRange, (int)maxRange)));
                return lowerLeft;
            }

            else

                return Vector2.Zero;
        }


        public void LoadContent(ContentManager content)
        {
            
        }
    }
}
