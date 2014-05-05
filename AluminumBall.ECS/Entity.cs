using AluminumBall.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS
{
    public class Entity
    {
        public Dictionary<string, IComponent> Components { get; set; }
        public Guid ID { get; set; }

        public Entity()
        {
            Components = new Dictionary<string, IComponent>();
        }

        public Entity AddComponent(IComponent component)
        {
            Components.Add(component.GetName(), component);

            return this;
        }
        

    }
}
