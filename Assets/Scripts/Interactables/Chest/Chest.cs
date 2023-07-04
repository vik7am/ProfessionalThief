using ProfessionalThief.Items;
using UnityEngine;

namespace ProfessionalThief.Interactables
{
    public interface IInteractable{
        void Interact(Interactor interactor);
        string InteractionMessage();
    }

    public abstract class Chest : MonoBehaviour, IInteractable
    {
        protected bool isEmpty;
        protected Item item;
        protected Item itemPrefab;

        public bool IsEmpty => isEmpty;

        private void Start(){
            isEmpty = false;
            SetItemPrefab();
            InitializeItem();
        }

        protected virtual void InitializeItem(){
            item = Instantiate<Item>(itemPrefab);
            item.AddItemsToStack(GetStackSize());
            item.transform.SetParent(transform);
        }

        public void Interact(Interactor interactor){
            if(isEmpty) return;
            IItemInventory inventory = interactor.GetComponent<IItemInventory>();
            if(inventory != null){
                inventory.AddItem(item);
                isEmpty = true;
            }
        }

        protected virtual int GetStackSize(){
            return 1;
        }

        public abstract void SetItemPrefab();
        public abstract string InteractionMessage();
        
        
    }
}
