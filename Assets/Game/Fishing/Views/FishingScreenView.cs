using System;
using System.Collections.Generic;
using Game.Fishing.Data;
using Game.Fishing.Models;
using UnityEngine;

namespace Game.Fishing.Views
{
    public sealed class FishingScreenView : MonoBehaviour
    {
        [SerializeField] private CreatureMovementView creatureMovementView;
        [SerializeField] private RodMovementOptionsView rodMovementOptionsView;
        [SerializeField] private ResultPopupView resultPopupView;

        public void ShowCreatureMovement(MovementPatternDefinition movement, float clarity)
        {
            if (creatureMovementView == null)
            {
                Debug.LogWarning("FishingScreenView is missing CreatureMovementView. TODO: assign it in the Inspector.");
                return;
            }

            creatureMovementView.ShowMovement(movement, clarity);
        }

        public void ShowRodOptions(
            IReadOnlyList<RodMovementDefinition> options,
            Action<RodMovementDefinition> onSelected)
        {
            if (rodMovementOptionsView == null)
            {
                Debug.LogWarning("FishingScreenView is missing RodMovementOptionsView. TODO: assign it in the Inspector.");
                return;
            }

            rodMovementOptionsView.ShowOptions(options, onSelected);
        }

        public void ShowResult(CatchResult result)
        {
            if (resultPopupView == null)
            {
                Debug.LogWarning("FishingScreenView is missing ResultPopupView. TODO: assign it in the Inspector.");
                return;
            }

            resultPopupView.ShowResult(result);
        }
    }
}
