using System.Collections.Generic;

namespace MiniUpgradeSystem
{
    public class UpgradeItem
    {
        public string Id;
        public string Title;
        public List<string> AffectedEntityIds;
        public UpgradeType Type;
        public float Multiplier;
    }
}