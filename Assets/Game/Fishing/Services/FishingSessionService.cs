using System;
using System.Collections.Generic;
using Game.Fishing.Data;
using Game.Fishing.Models;

namespace Game.Fishing.Services
{
    public sealed class FishingSessionService
    {
        private readonly CreatureSpawnService creatureSpawnService;
        private readonly RodMovementOptionsService rodMovementOptionsService;

        public FishingSessionService()
            : this(new CreatureSpawnService(), new RodMovementOptionsService())
        {
        }

        public FishingSessionService(
            CreatureSpawnService creatureSpawnService,
            RodMovementOptionsService rodMovementOptionsService)
        {
            this.creatureSpawnService = creatureSpawnService ?? throw new ArgumentNullException(nameof(creatureSpawnService));
            this.rodMovementOptionsService = rodMovementOptionsService ?? throw new ArgumentNullException(nameof(rodMovementOptionsService));
        }

        public FishingSession CreateSession(
            ZoneDefinition zone,
            FishingRodDefinition rod,
            IReadOnlyList<RodMovementDefinition> availableRodMovements)
        {
            if (zone == null)
            {
                throw new ArgumentNullException(nameof(zone));
            }

            if (rod == null)
            {
                throw new ArgumentNullException(nameof(rod));
            }

            CreatureDefinition creature = creatureSpawnService.SpawnCreature(zone);
            float clarity = rod.GetClarity(creature.Rarity);
            IReadOnlyList<RodMovementDefinition> rodMovementOptions =
                rodMovementOptionsService.CreateOptions(creature, availableRodMovements, clarity);

            return new FishingSession(zone, creature, rod, clarity, rodMovementOptions);
        }
    }
}
