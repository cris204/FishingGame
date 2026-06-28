using System.Collections.Generic;
using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "ZoneDefinition",
        menuName = "Game/Fishing/Zone")]
    public sealed class ZoneDefinition : ScriptableObject
    {
        public string Id;
        public int ZoneNumber;
        public string DisplayName;
        public int Difficulty;
        public List<CreatureDefinition> Creatures = new List<CreatureDefinition>();
        public List<ZoneDefinition> PossibleUnlocks = new List<ZoneDefinition>();
    }
}
