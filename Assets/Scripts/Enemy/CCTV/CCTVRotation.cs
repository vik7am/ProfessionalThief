using UnityEngine;

namespace ProfessionalThief
{
    public enum RotationDirection{
        ClockWise = -1,
        AntiClockWise = 1
    }

    public class CCTVRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float maxRotationAngle;
        private float currentRotationAngle;
        private int currentRotationDirection;
        private float deltaRotation;
        private bool isRotationActive;
        
        private void Start(){
            currentRotationDirection = (int)RotationDirection.ClockWise;
        }

        private void Update(){
            if(!isRotationActive)
                return;
            UpdateRotationDirection();
            RotateCCTV();
        }

        private void RotateCCTV(){
            deltaRotation = currentRotationDirection * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, deltaRotation, Space.Self);
        }

        private void UpdateRotationDirection(){
            currentRotationAngle = transform.localRotation.z;
            if(Mathf.Abs(currentRotationAngle) > maxRotationAngle){
                if(currentRotationAngle > 0)
                    currentRotationDirection = (int)RotationDirection.ClockWise;
                else
                    currentRotationDirection = (int)RotationDirection.AntiClockWise;
            }
        }

        public void SetRotationActive(bool state){
            isRotationActive = state;
        }
    }
}
