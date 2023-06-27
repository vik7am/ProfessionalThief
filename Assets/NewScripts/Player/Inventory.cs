using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.Item;


namespace ProfessionalThief.Player
{
    public class Inventory : MonoBehaviour
    {
        private Dictionary<ValuableId, Valuable> valuableList;
        private Dictionary<GadgetId, Gadget> gadgetList;
        private int totalTake;

        public static event Action<Valuable ,int> onValuableAdded;
        public static event Action<Gadget> onGadgetAdded;
        public static event Action<int> onTotalTakeUpdated;
        

        private void Start(){
            valuableList = new Dictionary<ValuableId, Valuable>();
            gadgetList = new Dictionary<GadgetId, Gadget>();
            totalTake = 0;
        }

        public void AddGadget(Gadget gadget){
            gadgetList.Add(gadget.id, gadget);
            onGadgetAdded?.Invoke(gadget);
        }

        public void AddValuable(Valuable valuable , int quantity){
            valuableList.Add(valuable.id, valuable);
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
