using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Util;
using ProfessionalThief.Player;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        private bool isDetectionActive;
        [SerializeField] private Light2D light2D;

        public void SetDetectionActive(bool status){
            isDetectionActive = status;
            light2D.enabled = status;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(!isDetectionActive) return;
            if(other.GetComponent<PlayerController>()){
                GameManager.Instance.ActivateAlarm();
            }
        }
    }
}
