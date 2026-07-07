using Game.Fishing.Data;

namespace Game.Fishing.Models
{
    public sealed class FishingLoadout
    {
        public FishingLoadout(FishingRodDefinition rod, FishingBaitDefinition bait)
        {
            Rod = rod;
            Bait = bait;
        }

        public FishingRodDefinition Rod { get; }

        // TODO: Wire bait into spawn rules when bait effects are added to FishingSessionService.
        public FishingBaitDefinition Bait { get; }
    }
}
