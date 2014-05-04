using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.Components
{
    public class Velocity: IComponent
    {
        public Vector2 Vector { get; set; }

        public Velocity(float x, float y)
        {
            Vector = new Vector2(x, y);
        }

        public string GetName()
        {
            return "Velocity";
        }
    }
}
