using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCrab
{
    class CBaitMachine : Component, IUpdateable
    {
        private Vector2 origin;
        private float minRange;
        private float maxRange;
        private Random rnd;

        private float baitTimer = 0;



        public CBaitMachine(GameObject go) : base(go)
        {
            origin = go.Transform.position;
        }
       
        public void Update()
        {
            
            //Update the enemy creation timer
            //this.baitTimer += GameWorld.gameWorld

            //Check if 5 seconds has elapsed
            if (this.baitTimer >= 5)
            {
                //Create a new enemy
                

                //Add the enemy to the enemy list
                

                //Reset your counter
                this.baitTimer = 0;
            }
        }
    }
}
