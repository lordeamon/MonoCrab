using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoCrab
{
    class CAnimator : Component,IUpdateable, ILoadable
    {
        private CSpriteRenderer spriteRenderer;
        private int currentIndex;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }
        private float timeElapsed;
        private float fps;
        private Rectangle[] rectangles;
        //The amount of pictures in your picture strip
        private int stripLength = 8;
        private string animationName;
        public string AnimationName
        {
            get { return animationName; }
            set { animationName = value; }
        }

        //private Dictionary<string, Animation> animations;

        public Dictionary<string, Animation> animations;
        

       


        public CAnimator(GameObject gameObject) : base (gameObject)
        {
            
            fps = 5;
            animations = new Dictionary<string, Animation>();
            this.spriteRenderer = (CSpriteRenderer)gameObject.GetComponent("CSpriteRenderer");
            
        }
        public void LoadContent(ContentManager content)
        {
            //int width = (spriteRenderer.Sprite.Width / animations[animationName].Fps;
            //rectangles = new Rectangle[stripLength];
            //for (int i = 0; i < stripLength; i++)
            //{
            //    rectangles[i] = new Rectangle(i * width, 0, width, spriteRenderer.Sprite.Height);
            //}
        }
        public void CreateAnimation(string name, Animation animation)
        {
            animations.Add(name, animation);
           // rectangles = animation.Rectangles;

        }
        public void Update()
        {
            timeElapsed += GameWorld.gameWorld.deltaTime;
            CurrentIndex = (int)(timeElapsed*fps);
            //restarts the animation
            if (CurrentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(AnimationName);
                timeElapsed = 0;
                CurrentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[CurrentIndex];
        }

        

        public void PlayAnimation(string animationName)
        {
            //Checks if it's a new animation
            if (this.AnimationName != animationName)
            {
                this.rectangles = animations[animationName].Rectangles;
                this.spriteRenderer.Rectangle = rectangles[0];
                this.spriteRenderer.Offset = animations[animationName].Offset; 
                this.AnimationName = animationName;
                this.fps = animations[animationName].Fps;

                timeElapsed = 0;
                CurrentIndex = 0;
            }
            
        }

        
    }
}
