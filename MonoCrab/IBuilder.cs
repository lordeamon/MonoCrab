using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MonoCrab
{
    interface IBuilder
    {
        GameObject GetResult();

        void BuildGameObject(Vector2 position);
    }
}
