using AluminumBall.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall
{
    public class Entity
    {
        public Entity()
        {
            Components = new List<IComponent>();
        }

        public List<IComponent> Components { get; set; }
    }
}
