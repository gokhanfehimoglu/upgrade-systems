using System.Collections.Generic;

namespace MiniUpgradeSystem
{
    public class IAPUpgradeSystem : UpgradeSystem
    {
        private readonly Dictionary<string, UpgradeItem> _items = new();
        
        protected override Dictionary<string, UpgradeItem> GetItems()
        {
            return _items;
        }
    }
}