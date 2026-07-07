using System;
using System.Collections.Generic;
using Game.Fishing.Data;

namespace Game.Fishing.Services
{
    public sealed class RodMovementOptionsService
    {
        private readonly Random random;

        public RodMovementOptionsService()
            : this(new Random())
        {
        }

        public RodMovementOptionsService(Random random)
        {
            this.random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public IReadOnlyList<RodMovementDefinition> CreateOptions(
            CreatureDefinition creature,
            IReadOnlyList<RodMovementDefinition> availableRodMovements,
            float clarity)
        {
            if (creature == null)
            {
                throw new ArgumentNullException(nameof(creature));
            }

            if (creature.RequiredRodMovement == null)
            {
                throw new InvalidOperationException("Creature has no required rod movement. TODO: designer must assign required rod movements per creature.");
            }

            if (availableRodMovements == null)
            {
                throw new ArgumentNullException(nameof(availableRodMovements));
            }

            int optionCount = GetOptionCount(clarity);
            List<RodMovementDefinition> falseOptions = new List<RodMovementDefinition>();

            foreach (RodMovementDefinition rodMovement in availableRodMovements)
            {
                if (rodMovement != null && rodMovement != creature.RequiredRodMovement && !falseOptions.Contains(rodMovement))
                {
                    falseOptions.Add(rodMovement);
                }
            }

            Shuffle(falseOptions);

            List<RodMovementDefinition> options = new List<RodMovementDefinition>();
            options.Add(creature.RequiredRodMovement);

            foreach (RodMovementDefinition falseOption in falseOptions)
            {
                if (options.Count >= optionCount)
                {
                    break;
                }

                options.Add(falseOption);
            }

            Shuffle(options);
            return options;
        }

        public int GetOptionCount(float clarity)
        {
            if (clarity >= 0.9f)
            {
                return 3;
            }

            if (clarity >= 0.5f)
            {
                return 5;
            }

            if (clarity >= 0.25f)
            {
                return 6;
            }

            return 8;
        }

        private void Shuffle(List<RodMovementDefinition> rodMovements)
        {
            for (int index = rodMovements.Count - 1; index > 0; index--)
            {
                int swapIndex = random.Next(index + 1);
                RodMovementDefinition current = rodMovements[index];
                rodMovements[index] = rodMovements[swapIndex];
                rodMovements[swapIndex] = current;
            }
        }
    }
}
