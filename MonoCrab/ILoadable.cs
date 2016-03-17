using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace MonoCrab
{
    interface ILoadable
    {
        void LoadContent(ContentManager content);
    }
}
