using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoCrab
{
    enum Direction
    {
        Back,Front,Right,Left
    }
    interface IStrategy
    {
        void Update(ref Direction direction);
    }
}
