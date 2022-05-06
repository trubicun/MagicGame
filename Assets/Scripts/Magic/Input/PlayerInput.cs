using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Magic.Input 
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        public ReactiveProperty<Vector2> MoveInput { get; } = new ReactiveProperty<Vector2>();
        public ReactiveProperty<Vector2> LookInput { get; } = new ReactiveProperty<Vector2>();
        public IObservable<InputAction> OnFire { get; private set; }

        Subject<InputAction> onFire = new Subject<InputAction>();


        void Awake()
        {
            OnFire = onFire.AsObservable();
        }

        public void Move(InputAction.CallbackContext context)
        {
            MoveInput.Value = context.ReadValue<Vector2>();
        }

        public void Look(InputAction.CallbackContext context)
        {
            LookInput.Value = context.ReadValue<Vector2>();
        }

        public void Fire(InputAction.CallbackContext context)
        {
            onFire.OnNext(context.action);
        }
    }
}