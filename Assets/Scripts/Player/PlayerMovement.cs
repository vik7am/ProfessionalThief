using System;
using UnityEngine;

namespace ProfessionalThief
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        private Rigidbody2D body;
        PlayerInput playerInput;
        Vector2 currentVelocity;

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            playerInput = GetComponent<PlayerInput>();
        }

        void Update()
        {
            UpdatePlayerRotation();
        }

        void FixedUpdate()
        {
            UpdatePlayerMovement();
        }

        private void UpdatePlayerMovement()
        {
            currentVelocity = playerInput.MovementInput.normalized;
            body.velocity = currentVelocity * speed;
        }

        void UpdatePlayerRotation()
        {
            if(playerInput.MovementInput == Vector2.zero) return;
            transform.right = playerInput.MovementInput.normalized;
        }

        public void StopMovement()
        {
            currentVelocity = Vector2.zero;
        }
    }
}
