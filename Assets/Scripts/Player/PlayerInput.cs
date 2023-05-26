using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 movementInput;
        private Vector2 prevMovementInput;
        private bool inputDisabled;
        
        public Vector2 MovementInput { get=> movementInput; }

        private void Start() {
            inputDisabled = false;
        }

        void Update()
        {
            if(inputDisabled) return;
            GetPlayerMovementInput();
        }

        private void GetPlayerMovementInput()
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");
        }

        public void DisableInput(bool status)
        {
            inputDisabled = status;
            movementInput = Vector2.zero;
        }
    }
}
