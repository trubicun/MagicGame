using Magic.Settings;
using UnityEngine;
using Zenject;

namespace Magic.Player
{
    /// <summary>
    /// Applies movement to player
    /// </summary>
    public class PlayerMovementHandler : IInitializable, IFixedTickable
    {
        InputSettings inputSettings;
        IPlayerMovement playerMovement;
        Rigidbody rigidbody;
        
        [Inject]
        public void Init(InputSettings inputSettings, IPlayerMovement playerMovement, Rigidbody rigidbody)
        {
            this.inputSettings = inputSettings;
            this.playerMovement = playerMovement;
            this.rigidbody = rigidbody;
        }

        public void Initialize()
        {
            rigidbody.drag = inputSettings.Drag;
        }
        
        public void FixedTick()
        {
            Move(playerMovement.MoveDirection.Value);
        }
        
        void Move(Vector3 moveDirection)
        {
            rigidbody.AddForce(moveDirection, ForceMode.Force);
        }
        
        // void SpeedControl()
        // {
        //     Vector3 velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
        //
        //     if (!(velocity.magnitude > inputSettings.MoveSpeed)) return;
        //     var limitedVelocity = velocity.normalized * inputSettings.MoveSpeed;
        //     rigidbody.velocity = new Vector3(limitedVelocity.x, rigidbody.velocity.y, limitedVelocity.z);
        // }
    }
}
