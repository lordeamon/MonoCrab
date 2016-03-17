using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCrab
{
    class CBait : Component, ILoadable, IUpdateable, IDrawable, IOnCollisionEnter
    {
        public CBait(GameObject gameObject) : base(gameObject)
        {
           // GameWorld.gameWorld.BaitList.Add(gameObject);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }
        public void CreateAnimations()
        {
            
        }

        public void OnCollisionEnter(CCollider other)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
