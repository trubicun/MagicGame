using Magic.Input;
using Magic.Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace Magic.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] Camera playerCamera;
        [SerializeField] Transform orientation;
        
        InputSettings inputSettings;
        IPlayerInput playerInput;
        
        float xRotation;
        float yRotation;

        [Inject]
        void Init(InputSettings inputSettings, IPlayerInput playerInput)
        {
            this.inputSettings = inputSettings;
            this.playerInput = playerInput;
        }
        
        void Awake()
        {
            //TODO: Move to Settings
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerInput.Look
                .Subscribe(OnLook)
                .AddTo(this);
        }

        void OnLook(Vector2 look)
        {
            var lookX = look.x;
            if (inputSettings.InverseX) lookX *= -1;

            var lookY = look.y;
            if (!inputSettings.InverseY) lookY *= -1;
            
            xRotation += lookX * Time.deltaTime * inputSettings.SensetivityX;
            yRotation += lookY * Time.deltaTime * inputSettings.SensetivityY;

            yRotation = Mathf.Clamp(yRotation, -inputSettings.MaxYAngle, inputSettings.MaxYAngle);

            playerCamera.transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
            orientation.rotation = Quaternion.Euler(0, xRotation,0);
        }
    }
}