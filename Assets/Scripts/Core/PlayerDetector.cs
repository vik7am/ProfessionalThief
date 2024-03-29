using ProfessionalThief.Player;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.Core
{
    public class PlayerDetector : MonoBehaviour
    {
        private bool isDetectionActive;
        [SerializeField] private Light2D light2D;
        [SerializeField] private string detectorName;

        private void Start() {
            SetDetectionActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(!isDetectionActive) return;
            if(other.GetComponent<PlayerController>()){
                GameManager.Instance.ActivateAlarm(detectorName);
            }
        }
        
        public void SetDetectionActive(bool status){
            isDetectionActive = status;
            light2D.enabled = status;
        }
    }
}
