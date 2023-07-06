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

        protected override void InitializeItem(){
            base.InitializeItem();
            valuable = item.GetComponent<Valuable>();
            valuable.Initialize(valuableData);
            item.SetItemId((ItemId)valuable.ValuableId);
        }

        private ValuableData GetValuableData(){
            int randomValuableIndex = Random.Range(0, valuableDataList.Count);
            return valuableDataList[randomValuableIndex];
        }

        private int GetRandomValueInRange(int min, int max){
            return Random.Range(min, max+1);
        }

        protected override int GetStackSize(){
            return GetRandomValueInRange(valuableData.minStackSize, valuableData.maxStackSize);
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Valuables ";
        }

        public override void SetItemPrefab(){
            valuableData = GetValuableData();
            itemPrefab = valuablePrefab.GetComponent<Item>();
        }
    }
}
