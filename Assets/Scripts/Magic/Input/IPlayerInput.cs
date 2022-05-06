using UniRx;
using UnityEngine;

namespace Magic.Input
{
    public interface IPlayerInput
    {
        ReactiveProperty<Vector2> MoveInput { get; }
        
        ReactiveProperty<Vector2> LookInput { get; }
    }   
}
