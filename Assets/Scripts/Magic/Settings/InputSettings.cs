using UnityEngine;

namespace Magic.Settings
{
    [CreateAssetMenu(fileName = "InputSettings", menuName = "Settings/InputSettings", order = 0)]
    public class InputSettings : ScriptableObject
    {
        [field: SerializeField] public float MaxYAngle { get; private set; } = 90f;

        [field: SerializeField] public float SensetivityX { get; private set; } = 1;
        [field: SerializeField] public bool InverseX { get; private set; } = false;

        [field: SerializeField] public float SensetivityY { get; private set; } = 1;
        [field: SerializeField] public bool InverseY { get; private set; } = false;
        
        [field: SerializeField] public float MoveSpeed { get; private set; } = 10;
        [field: SerializeField] public float Drag { get; private set; } = 1;
    }
}