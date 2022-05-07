using System;
using Magic.Input;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Magic.Bow
{
    public class BowAnimationHandler : MonoBehaviour
    {
        [SerializeField] Animator animator;
        
        IPlayerInput playerInput;
        
        static readonly int FireIn = Animator.StringToHash("FireIn");
        static readonly int FireOut = Animator.StringToHash("FireOut");

        [Inject]
        public void Init(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
        }

        void Start()
        {
            // playerInput.Action1
            //     .Subscribe(OnFire)
            //     .AddTo(this);
        }
        
        void OnFire(InputAction action)
        {
            switch (action.phase)
            {
                //Strted -> Perfomed -> Canceled
                case InputActionPhase.Started:
                    animator.SetTrigger(FireIn);
                    break;
                case InputActionPhase.Canceled:
                    animator.SetTrigger(FireOut);
                    break;
            }
        }
    }
}