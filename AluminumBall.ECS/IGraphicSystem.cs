using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS
{
    public interface IGraphicSystem
    {
        List<Entity> Query(Dictionary<Guid, Entity> entities);
        void Draw(Entity entity, SpriteBatch spriteBatch);
    }
}
