using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoCrab
{
    class CrabBuilder : IBuilder
    {
        private GameObject gameObject;

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {
            gameObject = new GameObject(position);
            gameObject.AddComponent(new CSpriteRenderer(gameObject, "crab", Color.White, 0.5f));
            gameObject.AddComponent(new CAnimator(gameObject));
            gameObject.AddComponent(new CCrab(gameObject));
            gameObject.AddComponent(new CCollider(gameObject, true,6));
            GameWorld.gameWorld.GameObjects.Add(gameObject);
        }
    }
}
