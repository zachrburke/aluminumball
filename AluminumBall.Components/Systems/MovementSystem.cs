using AluminumBall.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS.Systems
{
    public class MovementSystem : ILogicSystem
    {
        public List<Entity> Query(Dictionary<Guid, Entity> entities)
        {
            return entities.Values.Where(e => e.Components.ContainsKey("Position") && e.Components.ContainsKey("Velocity")).ToList();
        }

        public void Update(Entity entity, GameTime gameTime)
        {
            var position = entity.Components["Position"] as Position;
            var velocity = entity.Components["Velocity"] as Velocity;

            position.Vector += velocity.Vector * gameTime.ElapsedGameTime.Milliseconds;
            position.Vector += ECSManager.ClientAPI.Trajectory * gameTime.ElapsedGameTime.Milliseconds;
        }
    }
}
