using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Interactables
{
    public class MainGate : MonoBehaviour, IInteractableItem
    {
        private BoxCollider2D boxCollider2D;
        private bool isUnlocked;

        public bool IsUnlocked => isUnlocked;

        private void Awake() {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start(){
            GameManager.onMainObjectiveCompleted += UnlockDoor;
        }

        private void UnlockDoor(){
            isUnlocked = true;
        }

        public void Interact(Interactor interactor){
            if(!isUnlocked) return;
            GameManager.Instance.MissionCompleted();
        }

        public string InteractionMessage(){
            if(!isUnlocked)
                return "Steal the Gadget first";
            return " Press E to Exit";
        }
    }
}
