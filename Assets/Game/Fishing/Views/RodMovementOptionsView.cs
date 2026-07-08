using System;
using System.Collections.Generic;
using Game.Fishing.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Fishing.Views
{
    public sealed class RodMovementOptionsView : MonoBehaviour
    {
        [SerializeField] private Transform optionsRoot;
        [SerializeField] private Button optionButtonPrefab;

        private readonly List<Button> spawnedButtons = new List<Button>();
        private Action<RodMovementDefinition> onSelected;

        public void ShowOptions(
            IReadOnlyList<RodMovementDefinition> options,
            Action<RodMovementDefinition> onSelected)
        {
            ClearOptions();

            this.onSelected = onSelected;

            if (options == null || options.Count == 0)
            {
                Debug.LogWarning("RodMovementOptionsView received no options to display.");
                return;
            }

            if (optionsRoot == null || optionButtonPrefab == null)
            {
                Debug.LogWarning("RodMovementOptionsView needs Options Root and Option Button Prefab. TODO: assign UI references in the Inspector.");
                LogOptions(options);
                return;
            }

            foreach (RodMovementDefinition option in options)
            {
                CreateOptionButton(option);
            }
        }

        public void ClearOptions()
        {
            foreach (Button spawnedButton in spawnedButtons)
            {
                if (spawnedButton != null)
                {
                    Destroy(spawnedButton.gameObject);
                }
            }

            spawnedButtons.Clear();
            onSelected = null;
        }

        private void CreateOptionButton(RodMovementDefinition option)
        {
            Button button = Instantiate(optionButtonPrefab, optionsRoot);
            button.name = "RodMovementOption_" + GetOptionLabel(option);
            button.onClick.RemoveAllListeners();

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = GetOptionLabel(option);
            }

            RodMovementDefinition selectedOption = option;
            button.onClick.AddListener(() => HandleOptionSelected(selectedOption));

            spawnedButtons.Add(button);
        }

        private void HandleOptionSelected(RodMovementDefinition selectedOption)
        {
            if (onSelected == null)
            {
                Debug.LogWarning("Rod movement option selected, but no callback was registered.");
                return;
            }

            onSelected.Invoke(selectedOption);
        }

        private void LogOptions(IReadOnlyList<RodMovementDefinition> options)
        {
            foreach (RodMovementDefinition option in options)
            {
                Debug.Log("Rod movement option placeholder: " + GetOptionLabel(option));
            }
        }

        private string GetOptionLabel(RodMovementDefinition option)
        {
            if (option == null)
            {
                return "Missing option";
            }

            if (!string.IsNullOrWhiteSpace(option.DisplayName))
            {
                return option.DisplayName;
            }

            return option.name;
        }
    }
}
