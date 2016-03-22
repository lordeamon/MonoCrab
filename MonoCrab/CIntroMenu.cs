using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                GameWorld.gameWorld.startGame = true;
                GameWorld.gameWorld.GameObjects.Remove(this.gameObject);
                GameWorld.gameWorld.gameCamera.Zoom = 1f;
            }
        }
    }
}
