using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Items;

namespace ProfessionalThief.Player
{
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
            GameManager.onGamePaused += OnGamePaused;
            PlayerInventory.onGadgetAdded += gadgetController.AddGadget;
        }

        private void OnDisable() {
            GameManager.onGamePaused -= OnGamePaused;
            PlayerInventory.onGadgetAdded -= gadgetController.AddGadget;
        }

        private void OnGamePaused(bool status){
            movement.SetMovementActive(!status);
        }

        private void UpdatePlayerAnimation(){
            animator.SetFloat(AnimatorParameter.PLAYER_SPEED, movement.CurrentSpeed);
        }
    }
}
