using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Player
{
    public class PlayerInput : MonoBehaviour, IMovementInput
    {
        private Vector2 movementInput;

        public Vector2 GetMovementDirection(){
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");
            return movementInput.normalized;
        }
    }
}
