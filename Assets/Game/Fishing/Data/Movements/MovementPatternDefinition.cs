using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "MovementPatternDefinition",
        menuName = "Game/Fishing/Movement Pattern")]
    public sealed class MovementPatternDefinition : ScriptableObject
    {
        public string Id;
        public string DisplayName;
    }
}
