using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MonoCrab
{
    class CSpriteRenderer : Component,ILoadable, IDrawable
    {
        public Rectangle Rectangle { get; set; }
        private Texture2D sprite;
        private Vector2 offset;
        private Color color;
        
        public Color drawColor
        {
            get { return color; }
            set { color = value; }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
            set { value = sprite; }
        }

        public Vector2 Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }
        private string spriteName;
        private float layerDepth;

        public CSpriteRenderer(GameObject gameObject, string spriteName, Color drawColor, float layerDepth) : base (gameObject)
        {
            
            this.drawColor = drawColor;
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
            //If the user decides not to set a color, fall back to a color
            if (drawColor == null)
            {
                drawColor = Color.White;
            }
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            this.Rectangle = new Rectangle(0,0,sprite.Width,sprite.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, gameObject.Transform.position + Offset, Rectangle, drawColor, gameObject.Transform.rotation, Vector2.Zero, 1, SpriteEffects.None, layerDepth);

            //spriteBatch.Draw(Sprite, gameObject.Transform.position + Offset, Rectangle, drawColor, gameObject.Transform.rotation,new Vector2(Rectangle.Width / 2, Rectangle.Height / 2), 1, SpriteEffects.None, layerDepth);
        }
    }
}
