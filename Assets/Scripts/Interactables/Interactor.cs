using UnityEngine;
using System;

namespace ProfessionalThief.Interactables
{
    public class Interactor : MonoBehaviour
    {
        private IInteractableItem interactableItem;

        public static Action<IInteractableItem> onNearInteractableItem;

        private void Update(){
            if(Input.GetKeyDown(KeyCode.E)){
                InteractWithItem();
            }
        }

        private void InteractWithItem(){
            if(interactableItem == null) return;
            interactableItem.Interact(this);
            onNearInteractableItem?.Invoke(interactableItem);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.TryGetComponent<IInteractableItem>(out IInteractableItem item)){
                this.interactableItem = item;
                onNearInteractableItem?.Invoke(item);
            }
        }

        private void OnCollisionExit2D(Collision2D other) {
            if(other.gameObject.TryGetComponent<IInteractableItem>(out IInteractableItem item)){
                this.interactableItem = null;
                onNearInteractableItem?.Invoke(null);
            }
        }
    }
}
