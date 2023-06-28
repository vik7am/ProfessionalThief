using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;

namespace ProfessionalThief.Chest
{
    public class GadgetChest : Chest
    {
        [SerializeField] private Gadget gadgetPrefab;
        private Gadget gadget;

        protected override void InitializeItem(){
            gadget = Instantiate<Gadget>(gadgetPrefab);
        }

        public override void Interact(Interactor interactor){
            if(isEmpty) return;
            Inventory inventory = interactor.GetComponent<Inventory>();
            if(inventory){
                inventory.AddGadget(gadget);
                isEmpty = true;
            }
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Gadget";
        }
    }
}
