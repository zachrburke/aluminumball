using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS
{
    public interface ILogicSystem
    {
        List<Entity> Query(Dictionary<Guid, Entity> entities);
        void Update(Entity entity, GameTime gameTime);
    }
}
