using Magic.Input;
using Magic.Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace Magic.Player
{
    /// <summary>
    /// Calculate player movement
    /// </summary>
    public class PlayerMovement : IPlayerMovement, IFixedTickable
    {
        public ReactiveProperty<Vector3> MoveDirection { get; }
        
        InputSettings inputSettings;
        IPlayerInput playerInput;
        Transform playerOrientation;

        public PlayerMovement(IPlayerInput playerInput, InputSettings inputSettings, Transform playerOrientation)
        {
            this.inputSettings = inputSettings;
            this.playerOrientation = playerOrientation;
            this.playerInput = playerInput;
            MoveDirection = new ReactiveProperty<Vector3>();
        }

        Vector3 CalculateMovement(Transform orientation, Vector2 direction, float speed)
        {
            var moveVector = orientation.forward * direction.y + orientation.right * direction.x;
            moveVector = moveVector.normalized * speed;
            
            return moveVector;
        }
        
        public void FixedTick()
        {
            MoveDirection.Value = CalculateMovement(playerOrientation,playerInput.Move.Value, inputSettings.MoveSpeed);
        }
    }
}