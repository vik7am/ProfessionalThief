using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Core
{
    public interface IMovementInput{
        Vector2 GetMovementDirection();
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private new Rigidbody2D rigidbody2D;
        private Vector2 direction;
        private IMovementInput movementInput;
        private bool disableMovement;

        private void Awake(){
            rigidbody2D = GetComponent<Rigidbody2D>();
            movementInput = GetComponent<IMovementInput>();
        }

        private void Update(){
            if(movementInput == null || disableMovement)
                return;
            UpdateMovementDirection();
            UpdateLookDirection();
        }

        private void FixedUpdate(){
            if(movementInput == null)
                return;
            UpdateMovement();
        }

        private void UpdateMovementDirection(){
            direction = movementInput.GetMovementDirection();
        }

        private void UpdateLookDirection(){
            if(direction == Vector2.zero) return;
            transform.up = direction;
        }

        private void UpdateMovement(){
            rigidbody2D.velocity = direction * speed;
        }

        public void DisableMovement(bool status){
            if(!status)
                direction = Vector2.zero;
            disableMovement = status;
        }
    }
}
