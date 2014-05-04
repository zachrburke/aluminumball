using AluminumBall.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall
{
    public class GameState
    {
        public Dictionary<Guid, Entity> Entities { get; set; }

        public GameState()
        {
            Entities = new Dictionary<Guid, Entity>();
        }

        public void AddEntity(Entity entity)
        {
            var guid = Guid.NewGuid();
            Entities.Add(guid, entity);
            entity.ID = guid;
        }

        public void KillEntity(Guid guid)
        {
            Entities.Remove(guid);
        }
    }
}
