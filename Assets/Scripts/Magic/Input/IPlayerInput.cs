using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Magic.Input
{
    public interface IPlayerInput
    {
        ReactiveProperty<Vector2> MoveInput { get; }
        
        ReactiveProperty<Vector2> LookInput { get; }
        
        IObservable<InputAction> OnFire { get; }
    }   
}
