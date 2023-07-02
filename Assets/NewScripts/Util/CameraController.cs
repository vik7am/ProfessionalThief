using ProfessionalThief.Util;
using UnityEngine;

namespace ProfessionalThief
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private new Camera camera;
        private Vector3 cameraPosition;

        private void Start(){
            camera = GetComponent<Camera>();
            cameraPosition = transform.position;
        }

        private void LateUpdate() {
            cameraPosition.x = playerTransform.position.x;
            cameraPosition.y = playerTransform.position.y;
            transform.position = cameraPosition;
        }
    }
}
