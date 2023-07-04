using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.Items;

namespace ProfessionalThief.Player
{
    public class PlayerInventory : MonoBehaviour, IItemInventory
    {
        private Dictionary<ItemId, Item> itemList;
        private GadgetController gadgetController;
        private int totalTake;

        public static event Action<Valuable ,int> onValuableAdded;
        public static event Action<Gadget> onGadgetAdded;
        public static event Action<int> onTotalTakeUpdated;

        private void Awake() {
            gadgetController = GetComponent<GadgetController>();
        }
        
        private void Start(){
            itemList = new Dictionary<ItemId, Item>();
            totalTake = 0;
        }

        public void AddItem(Item item){
            if(item.ItemType == ItemType.VALUABLE){
                Valuable valuable = item.GetComponent<Valuable>();
                if(itemList.ContainsKey(item.ItemId)){
                    itemList[item.ItemId].AddItemsToStack(item.StackSize);
                }
                else{
                    itemList.Add(item.ItemId, item);
                }
                OnValuableAdded(valuable, item.StackSize);
            }
            else if(item.ItemType == ItemType.GADGET){
                Gadget gadget = item.GetComponent<Gadget>();
                itemList.Add(item.ItemId, item);
                OnGadgetAdded(gadget);
            }
        }

        public void OnValuableAdded(Valuable valuable , int quantity){
            onValuableAdded?.Invoke(valuable, quantity);
            UpdateTotalTake(valuable, quantity);
        }

        public void OnGadgetAdded(Gadget gadget){
            onGadgetAdded?.Invoke(gadget);
        }

        private void UpdateTotalTake(Valuable valuable, int stackSize){
            totalTake += valuable.Value * stackSize;
            onTotalTakeUpdated?.Invoke(totalTake);
        }
    }
}
