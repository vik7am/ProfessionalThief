using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProfessionalThief.Items
{
    public class GadgetController : MonoBehaviour
    {
        private Dictionary<ItemId, Gadget> gadgetList;
        private Gadget equippedGadget;
        
        public static Action<Gadget> onGadgetEquip;
        public static Action onGadgetUnEquip;

        private void Start(){
            gadgetList = new Dictionary<ItemId, Gadget>();
        }

        void Update(){
            EquipGadgetToggleInput();
            if(equippedGadget)
                UseEquippedGadgetToggleInput();
        }

        private void EquipGadgetToggleInput(){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                ToggleGadget(ItemId.GADGET_TORCH);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2)){
                ToggleGadget(ItemId.GADGET_STUN_GUN);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3)){
                ToggleGadget(ItemId.GADGET_NIGHT_VISION_GOGGLES);
            }
        }

        private void UseEquippedGadgetToggleInput(){
            if(Input.GetKeyDown(KeyCode.Space)){
                equippedGadget.ToggleState();
            }
        }

        public void AddGadget(Gadget gadget){
            gadgetList.Add(gadget.ItemId, gadget);
            gadget.transform.SetParent(this.transform);
            gadget.transform.localPosition = Vector2.zero;
        }

        private void ToggleGadget(ItemId itemId){
            if(!gadgetList.ContainsKey(itemId)) return;
            if(equippedGadget == null){
                EquipGadget(itemId);
            }
            else if(equippedGadget.ItemId == itemId){
                UnEquipGadget();
            }
            else{
                UnEquipGadget();
                EquipGadget(itemId);
            }
        }

        private void EquipGadget(ItemId itemId){
            equippedGadget = gadgetList[itemId];
            equippedGadget.Equip();
            onGadgetEquip?.Invoke(equippedGadget);
        }

        private void UnEquipGadget(){
            equippedGadget.UnEquip();
            onGadgetUnEquip?.Invoke();
            equippedGadget = null;
        }
    }
}
