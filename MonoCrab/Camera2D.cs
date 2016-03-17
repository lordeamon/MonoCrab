using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoCrab
{
    public class Camera2D
    {
        public Matrix viewMatrix;
        private Vector2 position;
        private Vector2 halfViewSize;
        private Vector2 target;
        private int targetIndex = 0;
        private KeyboardState keyState;
        KeyboardState oldState;
        KeyboardState oldState1;


        public Camera2D(Rectangle clientRect)
        {
            halfViewSize = new Vector2(clientRect.Width * 0.5f, clientRect.Height * 0.5f);
            UpdateViewMatrix();
        }

        public Vector2 Pos
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                UpdateViewMatrix();
            }
        }

        public void Update()
        {

            for (int i = 0; i < GameWorld.gameWorld.GameObjects.Count; i++)
            {
               // if (GameWorld.gameWorld.GameObjects[i].GetComponent("CCrab") != null)
               // {
                
                    target = GameWorld.gameWorld.GameObjects[targetIndex].Transform.position;
               // }

            }
            keyState = Keyboard.GetState();


            KeyboardState NewKeyState = Keyboard.GetState();

            if (NewKeyState.IsKeyDown(Keys.Q) && oldState.IsKeyUp(Keys.Q))
            {
                if (targetIndex < GameWorld.gameWorld.GameObjects.Count && targetIndex > 0)
                {
                    targetIndex--;
                }
                else
                {
                    targetIndex = GameWorld.gameWorld.GameObjects.Count - 1;
                }
            }
            oldState = NewKeyState;


            KeyboardState NewKey1State = Keyboard.GetState();

            if (NewKey1State.IsKeyDown(Keys.E) && oldState1.IsKeyUp(Keys.E))
            {
                if (targetIndex < GameWorld.gameWorld.GameObjects.Count - 1)
                {
                    targetIndex++;
                }
                else
                {
                    targetIndex = 0;
                }
                
            }
            oldState1 = NewKey1State;
            
            Pos = Vector2.Lerp(Pos, target, 10f * GameWorld.gameWorld.deltaTime);

            
            

        }
        private void UpdateViewMatrix()
        {
            viewMatrix = Matrix.CreateTranslation(halfViewSize.X - position.X, halfViewSize.Y - position.Y, 0.0f);
        }
    }
}