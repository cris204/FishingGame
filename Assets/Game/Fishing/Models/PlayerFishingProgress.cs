using System.Collections.Generic;
using Game.Fishing.Data;

namespace Game.Fishing.Models
{
    public sealed class PlayerFishingProgress
    {
        public PlayerFishingProgress()
        {
            DiscoveredZones = new List<ZoneDefinition>();
            CaughtCreatures = new List<CreatureDefinition>();
        }

        public List<ZoneDefinition> DiscoveredZones { get; }
        public List<CreatureDefinition> CaughtCreatures { get; }

        // TODO: Designer must define exact Mythic creature zone unlock rules before this grows.
    }
}
