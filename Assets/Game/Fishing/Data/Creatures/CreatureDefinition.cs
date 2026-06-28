using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "CreatureDefinition",
        menuName = "Game/Fishing/Creature")]
    public sealed class CreatureDefinition : ScriptableObject
    {
        public string Id;
        public string DisplayName;
        public Rarity Rarity;
        public float BaseAppearanceRate;
        public MovementPatternDefinition CreatureMovement;
        public RodMovementDefinition RequiredRodMovement;
        public bool UnlocksZone;
    }
}
