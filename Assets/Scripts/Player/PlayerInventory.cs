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
        private int totalItemValue;

        public static event Action<Valuable ,int> onValuableAdded;
        public static event Action<Gadget> onGadgetAdded;
        public static event Action<int> onTotalItemValueUpdated;

        private void Awake() {
            gadgetController = GetComponent<GadgetController>();
            itemList = new Dictionary<ItemId, Item>();
            totalItemValue = 0;
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
            UpdateTotalitemValue(valuable, quantity);
        }

        public void OnGadgetAdded(Gadget gadget){
            onGadgetAdded?.Invoke(gadget);
        }

        private void UpdateTotalitemValue(Valuable valuable, int stackSize){
            totalItemValue += valuable.Value * stackSize;
            onTotalItemValueUpdated?.Invoke(totalItemValue);
        }

        public int GetTotalItemValue(){
            return totalItemValue;
        }
    }
}
