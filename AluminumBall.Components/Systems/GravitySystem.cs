using AluminumBall.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS.Systems
{
    public class GravitySystem : ILogicSystem
    {
        public List<Entity> Query(Dictionary<Guid, Entity> entities)
        {
            return entities.Values.Where(e => e.Components.ContainsKey("Velocity") && e.Components.ContainsKey("Gravity")).ToList();
        }

        public void Update(Entity entity, Microsoft.Xna.Framework.GameTime gameTime)
        {
            var velocity = entity.Components["Velocity"] as Velocity;
            var gravity = entity.Components["Gravity"] as Gravity;

        }
    }
}
