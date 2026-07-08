using System;
using System.Collections.Generic;
using Game.Fishing.Data;
using Game.Fishing.Models;
using Game.Fishing.Services;
using Game.Fishing.Views;
using UnityEngine;

namespace Game.Fishing.Controllers
{
    public sealed class FishingController : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField] private FishingScreenView fishingScreenView;

        [Header("Default Fishing Setup")]
        [SerializeField] private ZoneDefinition defaultZone;
        [SerializeField] private FishingRodDefinition equippedRod;
        [SerializeField] private List<RodMovementDefinition> availableRodMovements = new List<RodMovementDefinition>();

        private FishingSessionService fishingSessionService;
        private CatchResolverService catchResolverService;
        private FishingSession currentSession;

        private void Awake()
        {
            fishingSessionService = new FishingSessionService();
            catchResolverService = new CatchResolverService();
        }

        [ContextMenu("Start Fishing With Defaults")]
        public void StartFishing()
        {
            StartFishing(defaultZone, equippedRod);
        }

        public void StartFishing(ZoneDefinition zone, FishingRodDefinition rod)
        {
            if (!CanStartFishing(zone, rod))
            {
                return;
            }

            try
            {
                currentSession = fishingSessionService.CreateSession(zone, rod, availableRodMovements);
            }
            catch (Exception exception)
            {
                Debug.LogError("Could not start fishing session: " + exception.Message);
                return;
            }

            ShowCurrentSession();
        }

        private bool CanStartFishing(ZoneDefinition zone, FishingRodDefinition rod)
        {
            if (fishingScreenView == null)
            {
                Debug.LogError("FishingController is missing FishingScreenView. TODO: assign the scene view in the Inspector.");
                return false;
            }

            if (zone == null)
            {
                Debug.LogError("FishingController cannot start fishing without a zone.");
                return false;
            }

            if (rod == null)
            {
                Debug.LogError("FishingController cannot start fishing without an equipped rod.");
                return false;
            }

            if (availableRodMovements == null || availableRodMovements.Count == 0)
            {
                Debug.LogError("FishingController needs available rod movements. TODO: create and assign RodMovementDefinition assets.");
                return false;
            }

            return true;
        }

        private void ShowCurrentSession()
        {
            if (currentSession == null)
            {
                Debug.LogWarning("FishingController has no active session to show.");
                return;
            }

            MovementPatternDefinition movement = null;

            if (currentSession.Creature != null)
            {
                movement = currentSession.Creature.CreatureMovement;
            }

            fishingScreenView.ShowCreatureMovement(movement, currentSession.Clarity);
            fishingScreenView.ShowRodOptions(currentSession.RodMovementOptions, HandleRodMovementSelected);
        }

        private void HandleRodMovementSelected(RodMovementDefinition selectedRodMovement)
        {
            if (currentSession == null)
            {
                Debug.LogWarning("Rod movement selected, but there is no active fishing session.");
                return;
            }

            CatchResult result = catchResolverService.ResolveCatch(currentSession.Creature, selectedRodMovement);
            fishingScreenView.ShowResult(result);
            currentSession = null;
        }
    }
}
