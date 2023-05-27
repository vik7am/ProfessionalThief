using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        Rigidbody2D body;
        Vector2 currentVelocity;
        private Vector2 movementInput;

        void Awake(){
            body = GetComponent<Rigidbody2D>();
        }

        void Update(){
            GetPlayerMovementInput();
            UpdatePlayerRotation();
        }

        void FixedUpdate(){
            UpdatePlayerMovement();
        }

        private void GetPlayerMovementInput(){
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");
        }

        private void UpdatePlayerMovement(){
            currentVelocity = movementInput.normalized;
            body.velocity = currentVelocity * speed;
        }

        void UpdatePlayerRotation(){
            if(movementInput == Vector2.zero) return;
            transform.right = movementInput.normalized;
        }

        public void StopMovement(){
            currentVelocity = Vector2.zero;
        }
    }
}
