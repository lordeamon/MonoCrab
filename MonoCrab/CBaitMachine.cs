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
    class CBaitMachine : Component, IUpdateable
    {
        private Vector2 origin;
        private float minRange = 100;
        private float maxRange = 500;
        private Random rnd;

        private float timerLimit;
        private float timePassed = 0;



        public CBaitMachine(GameObject go, float timerLimit) : base(go)
        {
            origin = go.Transform.position;
            this.timerLimit = timerLimit;
            rnd = new Random(DateTime.Now.Millisecond);

        }
       
        public void Update()
        {
            

            //Check if 5 seconds has elapsed
            if (timePassed > timerLimit)
            {
                //int baitType = rnd.Next(0, 5);

                //if (baitType == 0)
                //{
                    //Create a new enemy
                    //Director Director = new Director(new NBait1());
                    //Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}

                //else if (baitType == 1)
                //{
                //    //Create a new enemy
                //    Director Director = new Director(new NBait3());
                //    Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}
                //else if (baitType == 2)
                //{
                //    //Create a new enemy
                //    Director Director = new Director(new NBait5());
                //    Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}
                //else if (baitType == 3)
                //{
                //    //Create a new enemy
                //    Director Director = new Director(new PBait1());
                //    Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}
                //else if (baitType == 4)
                //{
                //    //Create a new enemy
                //    Director Director = new Director(new PBait3());
                //    Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}
                //else if (baitType == 5)
                //{
                //    //Create a new enemy
                //    Director Director = new Director(new PBait5());
                //    Director.Construct(new Vector2(origin.X + 50, origin.Y + 50));

                //}
                

                //Reset your counter
                timePassed = 0;
            }
            
            timePassed += (float)GameWorld.gameWorld.deltaTime;
            //Update the enemy creation timer
            
        }

        private void CreateBuild()
        {

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


    }
}
