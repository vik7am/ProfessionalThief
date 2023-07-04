using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Items;

namespace ProfessionalThief.Interactables
{
    public class ValuableChest : Chest
    {
        [SerializeField] private Valuable valuablePrefab;
        [SerializeField] private List<ValuableData> valuableDataList;
        private ValuableData valuableData;
        private Valuable valuable;
        private int quantity;

        protected override void InitializeItem(){
            valuableData = GetValuableData();
            valuable = Instantiate<Valuable>(valuablePrefab);
            quantity = GetRandomValueInRange(valuableData.minStackSize, valuableData.maxStackSize);
            valuable.Initialize(valuableData, quantity);
            valuable.transform.SetParent(transform);
        }

        private ValuableData GetValuableData(){
            int randomValuableIndex = Random.Range(0, valuableDataList.Count);
            return valuableDataList[randomValuableIndex];
        }

        public override void Interact(Interactor interactor){
            if(isEmpty) return;
            IItemInventory inventory = interactor.GetComponent<IItemInventory>();
            if(inventory != null){
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
