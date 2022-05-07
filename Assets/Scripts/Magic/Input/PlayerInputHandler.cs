using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Magic.Input 
{
    /// <summary>
    /// Handles player input by Player Input Component
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        IPlayerInput playerInput;
        
        [Inject]
        void Init(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
        }

        //Called by Player Input Component
        public void Move(InputAction.CallbackContext context)
        {
            playerInput.Move.Value = context.ReadValue<Vector2>();
        }

        public void Look(InputAction.CallbackContext context)
        {
            playerInput.Look.Value = context.ReadValue<Vector2>();
        }

        public void Fire(InputAction.CallbackContext context)
        {
            playerInput.Action1.Value = context.action;
        }
    }
}