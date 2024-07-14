using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.UI;

namespace ProfessionalThief.Items
{
    public class GadgetController : MonoBehaviour
    {
        private Dictionary<GadgetId, Gadget> gadgetList;
        private Gadget equippedGadget;
        
        public static Action<Gadget> onGadgetEquip;
        public static Action onGadgetUnEquip;

        private void Start(){
            gadgetList = new Dictionary<GadgetId, Gadget>();
        }

        private void OnEnable() {
            HUDUI.onGadgetSelected += ToggleGadget;
            HUDUI.onUseGadget += UseSelectedGadget;
        }

        private void OnDisable() {
            HUDUI.onGadgetSelected -= ToggleGadget;
            HUDUI.onUseGadget -= UseSelectedGadget;
        }

        private void UseSelectedGadget(){
            if(equippedGadget)
                equippedGadget.ToggleState();
        }

        private void ToggleGadget(GadgetId gadgetId){
            if(!gadgetList.ContainsKey(gadgetId)) return;
            if(equippedGadget == null){
                EquipGadget(gadgetId);
            }
            else if(equippedGadget.GadgetId == gadgetId){
                UnEquipGadget();
            }
            else{
                UnEquipGadget();
                EquipGadget(gadgetId);
            }
        }

        private void EquipGadget(GadgetId gadgetId){
            equippedGadget = gadgetList[gadgetId];
            equippedGadget.Equip();
            onGadgetEquip?.Invoke(equippedGadget);
        }

        private void UnEquipGadget(){
            equippedGadget.UnEquip();
            onGadgetUnEquip?.Invoke();
            equippedGadget = null;
        }

        public void AddGadget(Gadget gadget){
            gadgetList.Add(gadget.GadgetId, gadget);
            gadget.transform.SetParent(transform);
            gadget.transform.localPosition = Vector2.zero;
            gadget.transform.right = transform.right;
        }
    }
}
