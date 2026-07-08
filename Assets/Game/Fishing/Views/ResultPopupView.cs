using Game.Fishing.Models;
using TMPro;
using UnityEngine;

namespace Game.Fishing.Views
{
    public sealed class ResultPopupView : MonoBehaviour
    {
        [SerializeField] private GameObject popupRoot;
        [SerializeField] private TextMeshProUGUI resultLabel;

        public void ShowResult(CatchResult result)
        {
            if (popupRoot != null)
            {
                popupRoot.SetActive(true);
            }

            string resultText = CreateResultText(result);

            if (resultLabel != null)
            {
                resultLabel.text = resultText;
            }

            Debug.Log(resultText);

            // TODO: Replace this placeholder with the final result popup UI.
        }

        private string CreateResultText(CatchResult result)
        {
            if (result == null)
            {
                return "Fishing result missing.";
            }

            string creatureName = result.Creature != null ? result.Creature.DisplayName : "Unknown creature";

            if (result.Success)
            {
                return "Capture successful: " + creatureName;
            }

            return "Capture failed: " + creatureName;
        }
    }
}
