using System;
using Magic.Input;
using Magic.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Magic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody rigidbody;
        [SerializeField] Transform orientation;
        
        IPlayerInput playerInput;
        InputSettings inputSettings;

        Vector3 moveDirection = Vector3.zero;

        [Inject]
        public void Init(IPlayerInput playerInput, InputSettings inputSettings)
        {
            this.playerInput = playerInput;
            this.inputSettings = inputSettings;
        }
        
        void Awake()
        {
            rigidbody.freezeRotation = true;
            
            playerInput.MoveInput
                .ObserveEveryValueChanged(v => v.Value)
                .Subscribe(OnMove)
                .AddTo(this);

            playerInput.LookInput
                .ObserveEveryValueChanged(v => v.Value)
                .Subscribe(_ => OnMove(playerInput.MoveInput.Value))
                .AddTo(this);
        }
        
        void FixedUpdate()
        {
            Move(moveDirection);
        }

        void OnMove(Vector2 move)
        {
            moveDirection = orientation.forward * move.y + orientation.right * move.x;
        }

        void Move(Vector3 moveDirection)
        {
            rigidbody.AddForce(moveDirection.normalized * inputSettings.MoveSpeed, ForceMode.Force);
            rigidbody.drag = inputSettings.Drag;
            
            SpeedControl();
        }

        void SpeedControl()
        {
            Vector3 velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

            if (velocity.magnitude > inputSettings.MoveSpeed)
            {
                var limitedVelocity = velocity.normalized * inputSettings.MoveSpeed;
                rigidbody.velocity = new Vector3(limitedVelocity.x, rigidbody.velocity.y, limitedVelocity.z);
            }
        }
    }
}
