using System.Collections.Generic;
using System.Linq;

namespace MiniUpgradeSystem
{
    public abstract class UpgradeSystem
    {
        private Dictionary<string, UpgradeItem> UpgradeItems => GetItems();

        public float GetUpgrade(string entityId, UpgradeType upgradeType)
        {
            var sum = UpgradeItems
                .Where(item => item.Value.AffectedEntityIds.Contains(entityId)
                               && item.Value.Type == upgradeType)
                .Sum(item => item.Value.Multiplier);

            return sum;
        }

        public void AddItem(UpgradeItem item)
        {
            UpgradeItems.Add(item.Id, item);
        }

        public void RemoveItem(UpgradeItem item)
        {
            UpgradeItems.Remove(item.Id);
        }

        protected abstract Dictionary<string, UpgradeItem> GetItems();
    }
}