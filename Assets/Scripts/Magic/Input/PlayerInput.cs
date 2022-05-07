using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Magic.Input
{
    /// <summary>
    /// Observables for Player Inout
    /// </summary>
    public class PlayerInput : IPlayerInput
    {
        public ReactiveProperty<Vector2> Move { get; }
        public ReactiveProperty<Vector2> Look { get; }
        public ReactiveProperty<InputAction> Action1 { get; }

        public PlayerInput()
        {
            Move = new ReactiveProperty<Vector2>();
            Look = new ReactiveProperty<Vector2>();
            Action1 = new ReactiveProperty<InputAction>();
        }
    }
}