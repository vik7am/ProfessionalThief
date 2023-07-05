using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Player;

namespace ProfessionalThief.Interactables
{
    public class MainGate : MonoBehaviour, IInteractable
    {
        private BoxCollider2D boxCollider2D;
        private bool isUnlocked;

        public bool IsUnlocked => isUnlocked;

        private void Awake() {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnEnable() {
            GameManager.onMainObjectiveCompleted += UnlockDoor;
        }

        private void OnDisable(){
            GameManager.onMainObjectiveCompleted -= UnlockDoor;
        }

        private void UnlockDoor(){
            isUnlocked = true;
        }

        public void Interact(Interactor interactor){
            if(!isUnlocked) return;
            PlayerInventory playerInventory = interactor.GetComponent<PlayerInventory>();
            GameManager.Instance.ExitBuilding(playerInventory);
        }

        public string InteractionMessage(){
            if(!isUnlocked)
                return "Steal the Gadget first";
            return " Press E to Exit";
        }
    }
}
