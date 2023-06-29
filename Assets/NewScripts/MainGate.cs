using System;
using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Player;
using ProfessionalThief.Util;
using UnityEngine;

namespace ProfessionalThief
{
    public class MainGate : MonoBehaviour
    {
        private BoxCollider2D boxCollider2D;

        private void Awake() {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        void Start(){
            GameManager.onMainObjectiveCompleted += UnlockDoor;
        }

        private void UnlockDoor(){
            boxCollider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.GetComponent<PlayerController>()){
                GameManager.Instance.MissionCompleted();
            }
        }
    }
}
