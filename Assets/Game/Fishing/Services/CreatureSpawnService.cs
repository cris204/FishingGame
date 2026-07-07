using System;
using Game.Fishing.Data;

namespace Game.Fishing.Services
{
    public sealed class CreatureSpawnService
    {
        private readonly Random random;

        public CreatureSpawnService()
            : this(new Random())
        {
        }

        public CreatureSpawnService(Random random)
        {
            this.random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public CreatureDefinition SpawnCreature(ZoneDefinition zone)
        {
            if (zone == null)
            {
                throw new ArgumentNullException(nameof(zone));
            }

            if (zone.Creatures == null || zone.Creatures.Count == 0)
            {
                throw new InvalidOperationException("Zone has no configured creatures. TODO: assign creature-to-zone data when design defines it.");
            }

            float totalWeight = 0f;

            foreach (CreatureDefinition creature in zone.Creatures)
            {
                if (creature != null && creature.BaseAppearanceRate > 0f)
                {
                    totalWeight += creature.BaseAppearanceRate;
                }
            }

            if (totalWeight <= 0f)
            {
                throw new InvalidOperationException("Zone has no creatures with positive appearance rate.");
            }

            double roll = random.NextDouble() * totalWeight;
            float cumulativeWeight = 0f;
            CreatureDefinition fallbackCreature = null;

            foreach (CreatureDefinition creature in zone.Creatures)
            {
                if (creature == null || creature.BaseAppearanceRate <= 0f)
                {
                    continue;
                }

                fallbackCreature = creature;
                cumulativeWeight += creature.BaseAppearanceRate;

                if (roll <= cumulativeWeight)
                {
                    return creature;
                }
            }

            return fallbackCreature;
        }
    }
}
