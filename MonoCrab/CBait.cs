using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCrab
{
    class CBait : Component, ILoadable, IUpdateable, IOnCollisionEnter, IAnimateable
    {
        private CAnimator animator;

        private int energy;

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                energy = value;
            }
        }


        public CBait(GameObject gameObject, int energy) : base(gameObject)
        {
            this.Energy = energy;
            this.animator = (CAnimator)gameObject.GetComponent("CAnimator");
            GameWorld.gameWorld.BaitList.Add(gameObject);

        }

        public void LoadContent(ContentManager content)
        {
            CreateAnimations();
        }


        public void Update()
        {
            
        }

        public void CreateAnimations()
        { 
            if(Energy == -5 || Energy == 5)
            { 
            animator.CreateAnimation("Spin", new Animation(8, 0, 0, 180, 180, 8, Vector2.Zero));
            animator.PlayAnimation("Spin");
            }
            
            else if (Energy == -3 || Energy == 3 )
            {
                animator.CreateAnimation("Spin", new Animation(8, 0, 0, 150, 150, 8, Vector2.Zero));
                animator.PlayAnimation("Spin");
            }

            else if (Energy == -1 || Energy == 1)
            {
                animator.CreateAnimation("Spin", new Animation(8, 0, 0, 120, 120, 8, Vector2.Zero));
                animator.PlayAnimation("Spin");
            }
        }


        public void OnCollisionEnter(CCollider other)
        {
            if (other.gameObject.GetComponent("CCrab") != null)
            {
                CCrab tCrab = (CCrab)other.gameObject.GetComponent("CCrab");
                tCrab.Energy += Energy;
            }
        }

        

        public void OnAnimationDone(string animationName)
        {
            animator.PlayAnimation("Spin");
        }
    }
}
