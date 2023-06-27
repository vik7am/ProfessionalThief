using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Util;
using ProfessionalThief.Player;

namespace ProfessionalThief.Enemy
{
    public class PlayerDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.GetComponent<PlayerController>()){
                GameManager.Instance.ActivateAlarm();
            }
        }
    }
}
