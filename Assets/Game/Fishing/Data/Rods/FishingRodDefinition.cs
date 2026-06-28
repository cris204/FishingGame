using System.Collections.Generic;
using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "FishingRodDefinition",
        menuName = "Game/Fishing/Fishing Rod")]
    public sealed class FishingRodDefinition : ScriptableObject
    {
        public string Id;
        public string DisplayName;
        public List<RarityClarityEntry> ClarityByRarity = new List<RarityClarityEntry>();

        public float GetClarity(Rarity creatureRarity)
        {
            foreach (RarityClarityEntry entry in ClarityByRarity)
            {
                if (entry != null && entry.Rarity == creatureRarity)
                {
                    return entry.Clarity;
                }
            }

            return 0f;
        }
    }
}
