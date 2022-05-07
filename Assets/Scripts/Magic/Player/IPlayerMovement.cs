using UniRx;
using UnityEngine;

namespace Magic.Player
{
    public interface IPlayerMovement
    {
        ReactiveProperty<Vector3> MoveDirection { get; }
    }
}