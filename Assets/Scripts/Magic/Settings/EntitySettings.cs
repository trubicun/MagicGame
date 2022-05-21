using UnityEngine;

namespace Magic.Settings
{
    [CreateAssetMenu(fileName = "EntitySettings", menuName = "Settings/EntitySettings", order = 0)]
    public class EntitySettings : ScriptableObject
    {
        [field: SerializeField] public Player.Player Player { get; private set; }
    }
}