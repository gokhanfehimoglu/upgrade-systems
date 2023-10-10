using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniUpgradeSystem
{
    public class EntityManager : Singleton<EntityManager>
    {
        [SerializeField]
        private List<Entity> entities;

        public void UpdateEntityBubble(IEnumerable<string> ids)
        {
            foreach (var entity in ids.Select(id => entities.FirstOrDefault(entity => entity.GetId() == id)))
            {
                if (entity == default) return;

                entity.UpdateBubble();
            }
        }
    }
}