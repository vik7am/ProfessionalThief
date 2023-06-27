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

        private void Start() {
            RegisterForEvents();
        }

        private void RegisterForEvents(){
            GameManager.Instance.onGameOver += DisablePlayerMovement;
            GameManager.Instance.onMissionCompleted += DisablePlayerMovement;
        }

        private void DisablePlayerMovement(){
            movement.DisableMovement(true);
        }
    }
}
