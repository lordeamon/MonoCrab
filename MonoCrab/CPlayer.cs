using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCrab
{
    class CPlayer : Component, IUpdateable
    {

        public CPlayer(GameObject go) : base(go)
        {

        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
