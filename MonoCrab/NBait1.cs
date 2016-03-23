using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoCrab
{
    class NBait1 : IBuilder
    {
        private GameObject gameObject;

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new CSpriteRenderer(gameObject, "NegBait1", Color.White, 0.5f));
            gameObject.AddComponent(new CAnimator(gameObject));
            //gameObject.AddComponent(new CBait(gameObject, -1));
            gameObject.AddComponent(new CCollider(gameObject, true, 8));
            GameWorld.gameWorld.BaitList.Add(gameObject);
            GameWorld.gameWorld.GameObjects.Add(gameObject);
        }
    }
}