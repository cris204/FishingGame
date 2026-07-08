using Game.Fishing.Data;
using TMPro;
using UnityEngine;

namespace Game.Fishing.Views
{
    public sealed class CreatureMovementView : MonoBehaviour
    {
        [SerializeField] private GameObject placeholderRoot;
        [SerializeField] private TextMeshProUGUI movementLabel;
        [SerializeField] private TextMeshProUGUI clarityLabel;

        public void ShowMovement(MovementPatternDefinition movement, float clarity)
        {
            if (placeholderRoot != null)
            {
                placeholderRoot.SetActive(true);
            }

            string movementName = movement != null ? movement.DisplayName : "Unassigned movement";

            if (movementLabel != null)
            {
                movementLabel.text = movementName;
            }

            if (clarityLabel != null)
            {
                clarityLabel.text = "Clarity: " + Mathf.RoundToInt(clarity * 100f) + "%";
            }

            Debug.Log("Creature movement placeholder: " + movementName + " | clarity " + clarity);

            // TODO: Replace this placeholder with the final underwater creature movement visual.
            // The PDF does not define final movement patterns per creature yet.
        }
    }
}
