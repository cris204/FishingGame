using System.Collections.Generic;
using Game.Fishing.Data;

namespace Game.Fishing.Models
{
    public sealed class FishingSession
    {
        private readonly List<RodMovementDefinition> rodMovementOptions;

        public FishingSession(
            ZoneDefinition zone,
            CreatureDefinition creature,
            FishingRodDefinition rod,
            float clarity,
            IEnumerable<RodMovementDefinition> rodMovementOptions)
        {
            Zone = zone;
            Creature = creature;
            Rod = rod;
            Clarity = clarity;
            this.rodMovementOptions = new List<RodMovementDefinition>();

            if (rodMovementOptions != null)
            {
                foreach (RodMovementDefinition rodMovementOption in rodMovementOptions)
                {
                    this.rodMovementOptions.Add(rodMovementOption);
                }
            }
        }

        public ZoneDefinition Zone { get; }
        public CreatureDefinition Creature { get; }
        public FishingRodDefinition Rod { get; }
        public float Clarity { get; }
        public IReadOnlyList<RodMovementDefinition> RodMovementOptions
        {
            get { return rodMovementOptions; }
        }
    }
}
