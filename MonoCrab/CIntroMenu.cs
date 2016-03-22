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
        public CIntroMenu(GameObject gameObject) : base(gameObject)
        {
            
        }

        public void Update()
        {
            KeyboardState NewKeyState = Keyboard.GetState();

            if (NewKeyState.IsKeyDown(Keys.Enter) && !GameWorld.gameWorld.startGame)
            {
                GameWorld.gameWorld.gameCamera.shouldLerp = true;
                GameWorld.gameWorld.startGame = true;
                GameWorld.gameWorld.GameObjects.Remove(this.gameObject);
            }
            
        }
    }
}
