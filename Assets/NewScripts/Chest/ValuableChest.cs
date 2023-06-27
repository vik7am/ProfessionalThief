using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Item;

namespace ProfessionalThief.Chest
{
    public class ValuableChest : Chest
    {
        [SerializeField] private Valuable valuablePrefab;
        [SerializeField] private ValuableData valuableData;
        private Valuable valuable;
        private int quantity;

        protected override void InitializeItem(){
            quantity = GetRandomValueInRange(valuableData.minStackSize, valuableData.maxStackSize);
            valuable = new Valuable(valuableData);
        }

        public override void Interact(Interactor interactor){
            if(isEmpty) return;
            Inventory inventory = interactor.GetComponent<Inventory>();
            if(inventory){
                inventory.AddValuable(valuable, quantity);
                isEmpty = true;
            }
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Valuables ";
        }

        private int GetRandomValueInRange(int min, int max){
            return Random.Range(min, max+1);
        }
    }
}
