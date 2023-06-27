using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Player
{
    public class PlayerInput : MonoBehaviour, IMovementInput
    {
        private Vector2 movementInput;

        private void Start() {
            RegisterEvents();
        }

        private void RegisterEvents(){
        }

        public Vector2 GetMovementDirection(){
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");
            return movementInput.normalized;
        }
    }
}
