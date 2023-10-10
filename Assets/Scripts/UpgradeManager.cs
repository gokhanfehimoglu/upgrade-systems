using System.Collections.Generic;
using System.Linq;

namespace MiniUpgradeSystem
{
    public class UpgradeManager : Singleton<UpgradeManager>
    {
        private static readonly Dictionary<SystemType, UpgradeSystem> ActiveUpgradeSystems = new()
        {
            { SystemType.Iap, new IAPUpgradeSystem() },
            { SystemType.Skin, new SkinUpgradeSystem() }
        };

        public static float ApplyUpgrade(string entityId, float value, UpgradeType upgradeType)
        {
            var multiplier = ActiveUpgradeSystems.Sum(system => system.Value.GetUpgrade(entityId, upgradeType));
            return value * (1f + (upgradeType.Direction == UpgradeDirection.Increase ? multiplier : -multiplier));
        }

        public static void OnUpgradeItemStatusChange(SystemType type, UpgradeItem item, bool isActive)
        {
            if (isActive)
            {
                ActiveUpgradeSystems[type].AddItem(item);
            }
            else
            {
                ActiveUpgradeSystems[type].RemoveItem(item);
            }

            EntityManager.Instance.UpdateEntityBubble(item.AffectedEntityIds);
        }

        private readonly List<UpgradeItem> _iapUpgradeItems = new()
        {
            new UpgradeItem
            {
                Id = "forever_double_profit",
                Title = "Forever Double Profit",
                AffectedEntityIds = new List<string> { "stand_one", "stand_two" },
                Type = UpgradeType.Price,
                Multiplier = 1f
            },
            new UpgradeItem
            {
                Id = "no_ads",
                Title = "Remove Ads",
                AffectedEntityIds = new List<string> { "stand_one", "stand_two" },
                Type = UpgradeType.ProductionTime,
                Multiplier = 0.5f
            }
        };

        private readonly List<UpgradeItem> _skinUpgradeItems = new()
        {
            new UpgradeItem
            {
                Id = "fancy_skin",
                Title = "Fancy Skin",
                AffectedEntityIds = new List<string> { "stand_one" },
                Type = UpgradeType.Price,
                Multiplier = 0.2f
            },
            new UpgradeItem
            {
                Id = "halloween_skin",
                Title = "Halloween Skin",
                AffectedEntityIds = new List<string> { "stand_two" },
                Type = UpgradeType.ProductionTime,
                Multiplier = 0.3f
            },
            new UpgradeItem
            {
                Id = "roblox_skin",
                Title = "Roblox Skin",
                AffectedEntityIds = new List<string> { "stand_one" },
                Type = UpgradeType.Price,
                Multiplier = 0.3f
            }
        };

        public List<UpgradeItem> GetIapUpgradeItems()
        {
            return _iapUpgradeItems;
        }

        public List<UpgradeItem> GetSkinUpgradeItems()
        {
            return _skinUpgradeItems;
        }
    }

    public enum SystemType
    {
        Iap,
        Skin
    }
}