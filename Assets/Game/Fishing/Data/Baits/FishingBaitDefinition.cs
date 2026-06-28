using System.Collections.Generic;
using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "FishingBaitDefinition",
        menuName = "Game/Fishing/Fishing Bait")]
    public sealed class FishingBaitDefinition : ScriptableObject
    {
        public string Id;
        public string DisplayName;
        public FishingBaitRarity Rarity;
        public int InitialDurability;
        public List<BaitDurabilityCostEntry> DurabilityCosts = new List<BaitDurabilityCostEntry>();
        public List<BaitAppearanceBonusEntry> AppearanceBonuses = new List<BaitAppearanceBonusEntry>();
    }
}
