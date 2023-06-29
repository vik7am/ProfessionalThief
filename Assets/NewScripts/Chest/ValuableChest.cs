using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;

namespace ProfessionalThief.Chest
{
    public class ValuableChest : Chest
    {
        [SerializeField] private Valuable valuablePrefab;
        [SerializeField] private ValuableData valuableData;
        private Valuable valuable;
        private int quantity;

        protected override void InitializeItem(){
            valuable = Instantiate<Valuable>(valuablePrefab);
            quantity = GetRandomValueInRange(valuableData.minStackSize, valuableData.maxStackSize);
            valuable.Initialize(valuableData, quantity);
            valuable.transform.SetParent(transform);
        }

        public override void Interact(Interactor interactor){
            if(isEmpty) return;
            Inventory inventory = interactor.GetComponent<Inventory>();
            if(inventory){
                inventory.AddItem(valuable);
                isEmpty = true;
            }
        }

        private int GetRandomValueInRange(int min, int max){
            return Random.Range(min, max+1);
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Valuables ";
        }
    }
}
