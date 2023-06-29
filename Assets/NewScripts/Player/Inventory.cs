using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.Items;


namespace ProfessionalThief.Player
{
    public class Inventory : MonoBehaviour
    {
        private Dictionary<ValuableId, Valuable> valuableList;
        private Dictionary<GadgetId, Gadget> gadgetList;
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
            valuableList = new Dictionary<ValuableId, Valuable>();
            gadgetList = new Dictionary<GadgetId, Gadget>();
            itemList = new Dictionary<ItemId, Item>();
            totalTake = 0;
        }

        public void AddItem(Item item){
            if(item.Type == ItemType.VALUABLE){
                Valuable valuable = (Valuable)item;
                int stackSize = valuable.stackSize;
                if(itemList.ContainsKey(item.Id)){
                    Valuable v = (Valuable)itemList[item.Id];
                    v.stackSize += stackSize;
                    AddValuable(valuable, stackSize);
                    return;
                }
                itemList.Add(item.Id, item);
                AddValuable(valuable, stackSize);
            }
            else if(item.Type == ItemType.GADGET){
                Gadget gadget = item.GetComponent<Gadget>();
                itemList.Add(item.Id, item);
                AddGadget(gadget);
            }
        }

        public void AddGadget(Gadget gadget){
            gadgetController.AddGadget(gadget);
            onGadgetAdded?.Invoke(gadget);
        }

        public void AddValuable(Valuable valuable , int quantity){
            //valuableList.Add(valuable.id, valuable);
            onValuableAdded?.Invoke(valuable, quantity);
            UpdateTotalTake(valuable, quantity);
        }

        public bool HasGadget(GadgetId gadgetId){
            return gadgetList.ContainsKey(gadgetId);
        }

        public Gadget GetGadget(GadgetId gadgetId){
            if(!HasGadget(gadgetId)) return null;
            return gadgetList[gadgetId];
        }

        private void UpdateTotalTake(Valuable valuable, int stackSize){
            totalTake += valuable.value * stackSize;
            onTotalTakeUpdated(totalTake);
        }
    }
}
