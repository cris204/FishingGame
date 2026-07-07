using System;
using Game.Fishing.Data;
using Game.Fishing.Models;

namespace Game.Fishing.Services
{
    public sealed class CatchResolverService
    {
        public CatchResult ResolveCatch(CreatureDefinition creature, RodMovementDefinition selectedRodMovement)
        {
            if (creature == null)
            {
                throw new ArgumentNullException(nameof(creature));
            }

            bool success = creature.RequiredRodMovement != null && selectedRodMovement == creature.RequiredRodMovement;
            return new CatchResult(success, creature);
        }
    }
}
