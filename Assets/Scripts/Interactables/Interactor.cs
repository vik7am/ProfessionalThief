using UnityEngine;
using System;

namespace ProfessionalThief.Interactables
{
    public class Interactor : MonoBehaviour
    {
        private IInteractable interactable;

        public static Action<IInteractable> onNearInteractable;

        private void Update(){
            if(Input.GetKeyDown(KeyCode.E)){
                InteractWithItem();
            }
        }

        private void InteractWithItem(){
            if(interactable == null) return;
            interactable.Interact(this);
            onNearInteractable?.Invoke(interactable);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = interactable;
                onNearInteractable?.Invoke(interactable);
            }
        }

        private void OnCollisionExit2D(Collision2D other) {
            if(other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable)){
                this.interactable = null;
                onNearInteractable?.Invoke(null);
            }
        }
    }
}
