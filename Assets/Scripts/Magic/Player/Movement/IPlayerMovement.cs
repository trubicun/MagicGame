using UniRx;
using UnityEngine;

namespace Magic.Player.Movement
{
    public interface IPlayerMovement
    {
        ReactiveProperty<Vector3> MoveDirection { get; }
    }
}