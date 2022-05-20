using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Magic.Input
{
    /// <summary>
    /// Observables for Player Input
    /// </summary>
    public interface IPlayerInput
    {
        ReactiveProperty<Vector2> Move { get; }
        
        ReactiveProperty<Vector2> Look { get; }
        
        ReactiveProperty<InputAction> Action1 { get; }
    }   
}
