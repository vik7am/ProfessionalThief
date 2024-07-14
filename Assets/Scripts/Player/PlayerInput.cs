using UnityEngine;
using ProfessionalThief.Core;
using System;
using ProfessionalThief.UI;

namespace ProfessionalThief.Player
{
    public class PlayerInput : MonoBehaviour, IMovementInput
    {
        public Vector2 GetMovementDirection(){
            return UIManager.Instance.floatingJoystick.Direction.normalized;
        }
    }
}
