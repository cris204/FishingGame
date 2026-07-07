using Game.Fishing.Data;

namespace Game.Fishing.Models
{
    public sealed class CatchResult
    {
        public CatchResult(bool success, CreatureDefinition creature)
        {
            Success = success;
            Creature = creature;
        }

        public bool Success { get; }
        public CreatureDefinition Creature { get; }
    }
}
