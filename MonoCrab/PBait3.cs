using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoCrab
{
    class PBait3 : IBuilder
    {
        private GameObject gameObject;

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new CSpriteRenderer(gameObject, "PosBait3", Color.White, 1));
            gameObject.AddComponent(new CAnimator(gameObject));
            gameObject.AddComponent(new CCollider(gameObject, true, 8));
            gameObject.AddComponent(new CBait(gameObject, 3));
            GameWorld.gameWorld.BaitList.Add(gameObject);
            GameWorld.gameWorld.GameObjects.Add(gameObject);
        }
    }
}