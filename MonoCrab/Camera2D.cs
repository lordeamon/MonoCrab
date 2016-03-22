using System;
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
        private float cameraSpeed = 5;
        private int targetIndex = 0;
        private KeyboardState keyState;
        private MouseState mouseState; //Mouse state
        private int scroll;
        KeyboardState oldState;
        KeyboardState oldState1;
        
        private float zoom; // Camera Zoom
        public float Zoom
        {
            get { return zoom; }
            set { value = zoom; } // Negative zoom will flip image
        }
        public Camera2D(Rectangle clientRect)
        {
            zoom = 0.20f;
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
                if (!GameWorld.gameWorld.startGame)
                {
                    if (GameWorld.gameWorld.GameObjects[i].GetComponent("CIntroMenu") != null)
                    {
                        target = GameWorld.gameWorld.GameObjects[i].Transform.position;

                    }
                }
                else
                {
                     target = GameWorld.gameWorld.GameObjects[targetIndex].Transform.position;

                }

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
            
            Pos = Vector2.Lerp(Pos, target, cameraSpeed * GameWorld.gameWorld.deltaTime);
            //Check zoom
            mouseState = Mouse.GetState();
            if (mouseState.ScrollWheelValue > scroll)
            {
                zoom += 0.01f;
                scroll =  mouseState.ScrollWheelValue;
            }
            else if (mouseState.ScrollWheelValue < scroll)
            {
                zoom -= 0.01f;
                scroll = mouseState.ScrollWheelValue;
            }




        }
        private void UpdateViewMatrix()
        {
            //Clamp the value so we can't go below zero
            zoom = MathHelper.Clamp(zoom, 0.0f, 10.0f);
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateRotationZ(0.0f) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(halfViewSize.X , halfViewSize.Y , 0));
            

            //viewMatrix = Matrix.CreateTranslation(halfViewSize.X - position.X, halfViewSize.Y - position.Y, 0.0f);
        }
       
    }
}