using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.Components
{
    public class Gravity : IComponent
    {
        public float Acceleration { get; set; }

        public Gravity(float acceleration)
        {
            Acceleration = acceleration;
        }

        public string GetName()
        {
            return "Gravity";
        }
    }
}
