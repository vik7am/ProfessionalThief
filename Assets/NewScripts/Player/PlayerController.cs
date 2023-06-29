using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Util;

namespace ProfessionalThief.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Movement movement;

        private void Awake(){
            playerInput = GetComponent<PlayerInput>();
            movement = GetComponent<Movement>();
        }

        private void OnEnable() {
            GameManager.onGameOver += DisablePlayerMovement;
            GameManager.onMissionCompleted += DisablePlayerMovement;
        }

        private void OnDisable() {
            GameManager.onGameOver -= DisablePlayerMovement;
            GameManager.onMissionCompleted -= DisablePlayerMovement;
        }

        private void DisablePlayerMovement(){
            movement.SetMovementActive(false);
        }
    }
}
