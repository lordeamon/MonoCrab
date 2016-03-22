using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoCrab
{
    class CIntroMenu : Component, IUpdateable
    {
        private CSpriteRenderer spriteRenderer;
        private float fade = 1;
        public CIntroMenu(GameObject gameObject) : base(gameObject)
        {
            this.spriteRenderer = (CSpriteRenderer) gameObject.GetComponent("CSpriteRenderer");
        }

        public void Update()
        {
            KeyboardState NewKeyState = Keyboard.GetState();

            if (NewKeyState.IsKeyDown(Keys.Enter) && !GameWorld.gameWorld.startGame)
            {
                GameWorld.gameWorld.gameCamera.shouldLerp = true;
                GameWorld.gameWorld.startGame = true;
                
            }
            if (GameWorld.gameWorld.startGame)
            {
                //fade = MathHelper.Lerp(1, 0, 5f*GameWorld.gameWorld.deltaTime);
                spriteRenderer.fade -= 0.01f;
                if (spriteRenderer.fade <= 0)
                {
                GameWorld.gameWorld.GameObjects.Remove(this.gameObject);

                }
            }
            
        }
    }
}
