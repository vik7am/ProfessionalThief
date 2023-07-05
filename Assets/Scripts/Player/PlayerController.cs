using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Items;

namespace ProfessionalThief.Player
{
    public class AnimatorParameter{
        public static string PLAYER_SPEED = "speed";
    }

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private PlayerInput playerInput;
        private Movement movement;
        private GadgetController gadgetController;
        private PlayerInventory playerInventory;

        private void Awake(){
            playerInput = GetComponent<PlayerInput>();
            movement = GetComponent<Movement>();
            gadgetController = GetComponent<GadgetController>();
            playerInventory = GetComponent<PlayerInventory>();
        }

        private void Start() {
            GameManager.Instance.GetGadgetForPreviousLevels(playerInventory);
        }

        private void Update() {
            UpdatePlayerAnimation();
        }

        private void OnEnable() {
            GameManager.onGameOver += DisablePlayerMovement;
            GameManager.onLevelCompleted += DisablePlayerMovement;
            PlayerInventory.onGadgetAdded += gadgetController.AddGadget;
        }

        private void OnDisable() {
            GameManager.onGameOver -= DisablePlayerMovement;
            GameManager.onLevelCompleted -= DisablePlayerMovement;
            PlayerInventory.onGadgetAdded -= gadgetController.AddGadget;
        }

        private void DisablePlayerMovement(){
            movement.SetMovementActive(false);
        }

        private void UpdatePlayerAnimation(){
            animator.SetFloat(AnimatorParameter.PLAYER_SPEED, movement.CurrentSpeed);
        }
    }
}
