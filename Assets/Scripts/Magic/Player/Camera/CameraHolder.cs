using UnityEngine;

namespace Magic.Player.Camera
{
    public class CameraHolder : MonoBehaviour
    {
        [SerializeField] Transform cameraPosition;

        void Update()
        {
            transform.position = cameraPosition.position;
        }
    }
}
