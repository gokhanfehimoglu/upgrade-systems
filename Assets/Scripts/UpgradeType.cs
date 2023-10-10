namespace MiniUpgradeSystem
{
    public sealed class UpgradeType
    {
        public static readonly UpgradeType Price = new(UpgradeDirection.Increase);
        public static readonly UpgradeType ProductionTime = new(UpgradeDirection.Decrease);
        
        public readonly UpgradeDirection Direction;

        private UpgradeType(UpgradeDirection direction)
        {
            Direction = direction;
        }
    }
}