using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Item;

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
            Inventory inventory = interactor.GetComponent<Inventory>();
            if(inventory){
                inventory.AddGadget(gadget);
            }
        }
    }
}
