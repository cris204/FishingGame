using System;

namespace Game.Fishing.Data
{
    [Serializable]
    public sealed class BaitDurabilityCostEntry
    {
        public Rarity CreatureRarity;
        public bool IsAvailable;
        public int DurabilityCost;
    }
}
