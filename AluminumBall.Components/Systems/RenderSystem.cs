using AluminumBall.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.ECS.Systems
{
    public class RenderSystem : IGraphicSystem
    {
        public List<Entity> Query(Dictionary<Guid, Entity> entities)
        {
            return entities.Values.Where(e => e.Components.ContainsKey("Position") && e.Components.ContainsKey("Renderable")).ToList();
        }

        public void Draw(Entity entity, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            var position = entity.Components["Position"] as Position;
            var renderable = entity.Components["Renderable"] as Renderable;

            spriteBatch.Begin();
            spriteBatch.Draw(ECSManager.Textures[renderable.TexName], position.Vector, ECSManager.ClientAPI.BallColor);
            spriteBatch.End();
        }
    }
}
