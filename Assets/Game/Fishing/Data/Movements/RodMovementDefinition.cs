using UnityEngine;

namespace Game.Fishing.Data
{
    [CreateAssetMenu(
        fileName = "RodMovementDefinition",
        menuName = "Game/Fishing/Rod Movement")]
    public sealed class RodMovementDefinition : ScriptableObject
    {
        public string Id;
        public string DisplayName;
    }
}
