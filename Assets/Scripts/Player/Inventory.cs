using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.Items;


namespace ProfessionalThief.Player
{
    public class Inventory : MonoBehaviour
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
                Valuable valuable = (Valuable)item;
                int quantity = valuable.StackSize;
                if(itemList.ContainsKey(item.ItemId)){
                    ((Valuable)itemList[item.itemId]).AddToStack((Valuable)item);
                    AddValuable(valuable, quantity);
                    return;
                }
                itemList.Add(item.ItemId, item);
                AddValuable(valuable, valuable.StackSize);
            }
            else if(item.ItemType == ItemType.GADGET){
                Gadget gadget = (Gadget)item;
                itemList.Add(item.ItemId, item);
                AddGadget(gadget);
            }
        }

        public void AddGadget(Gadget gadget){
            gadgetController.AddGadget(gadget);
            onGadgetAdded?.Invoke(gadget);
        }

        public void AddValuable(Valuable valuable , int quantity){
            onValuableAdded?.Invoke(valuable, quantity);
            UpdateTotalTake(valuable, quantity);
        }

        private void UpdateTotalTake(Valuable valuable, int stackSize){
            totalTake += valuable.Value * stackSize;
            onTotalTakeUpdated?.Invoke(totalTake);
        }
    }
}
