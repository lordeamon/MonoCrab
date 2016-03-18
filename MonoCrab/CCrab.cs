using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoCrab
{
    internal class CCrab : Component, ILoadable, IUpdateable /*, IAnimateable*/, IDrawable, IOnCollisionEnter
    {
        private CAnimator animator;
        private CSpriteRenderer spriteRenderer;
        private List<Vector2> targets = new List<Vector2>();
        private int speed = 40;
        private float turnSpeed = 3;
        private Vector2 closestTarget;

        private int energy = 100;
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

        public CCrab(GameObject gameObject) : base(gameObject)
        {
            this.spriteRenderer = (CSpriteRenderer)gameObject.GetComponent("CSpriteRenderer");

            this.animator = (CAnimator)gameObject.GetComponent("CAnimator");
            gameObject.Transform.speed = speed;
            gameObject.Transform.turnSpeed = turnSpeed;
        }

        public void LoadContent(ContentManager content)
        {
            CreateAnimations();
        }

        /// <summary>
        /// Returns the closest bait
        /// </summary>
        /// <returns></returns>
        private Vector2 GetClosestBait()
        {
            float minDist = float.MaxValue;

            foreach (GameObject t in GameWorld.gameWorld.BaitList.ToList())
            {
                float dist = Vector2.Distance(t.Transform.position, gameObject.Transform.position);
                if (dist < minDist)
                {
                    closestTarget = t.Transform.position;
                    minDist = dist;
                }
            }
            return closestTarget;
        }

        public void Update()
        {
            GetClosestBait();
            gameObject.Transform.MoveTo(closestTarget, false);
            gameObject.Transform.LookAt(closestTarget);
        }

        public void OnAnimationDone(string animationName)
        {
            animator.PlayAnimation("Walk");

        }

        public void CreateAnimations()
        {
            //animator.CreateAnimation("Walk", new Animation(6, 0, 0, 107, 100, 10, Vector2.Zero));
            animator.CreateAnimation("Walk", new Animation(6, 0, 0, 256, 255, 10, Vector2.Zero));

            animator.PlayAnimation("Walk");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteRenderer.Sprite, gameObject.Transform.position + spriteRenderer.Offset, spriteRenderer.Rectangle, Color.White, gameObject.Transform.rotation, new Vector2(spriteRenderer.Sprite.Width / 255,spriteRenderer.Sprite.Height / 256), 1, SpriteEffects.None, 0.3f);

            //spriteBatch.Draw(Sprite, gameObject.Transform.position + Offset, Rectangle, drawColor, gameObject.Transform.rotation, Vector2.Zero, 1, SpriteEffects.None, layerDepth);

        }

        public void OnCollisionEnter(CCollider other)
        {
            if (other.gameObject.GetComponent("CBait") != null)
            {
                GameWorld.gameWorld.BaitList.Remove(other.gameObject);
                GameWorld.gameWorld.GameObjects.Remove(other.gameObject);
            }
        }
    }
}
