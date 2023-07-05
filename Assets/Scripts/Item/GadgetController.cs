using System.Collections.Generic;
using UnityEngine;
using System;
using ProfessionalThief.Core;

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
           // GameManager.Instance.GetGadgetForPreviousLevels(this);
        }

        void Update(){
            EquipGadgetToggleInput();
            if(equippedGadget)
                UseEquippedGadgetToggleInput();
        }

        private void EquipGadgetToggleInput(){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                ToggleGadget(GadgetId.TORCH);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2)){
                ToggleGadget(GadgetId.STUN_GUN);
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3)){
                ToggleGadget(GadgetId.NIGHT_VISION_GOGGLES);
            }
        }

        private void UseEquippedGadgetToggleInput(){
            if(Input.GetKeyDown(KeyCode.Space)){
                equippedGadget.ToggleState();
            }
        }

        public void AddGadget(Gadget gadget){
            gadgetList.Add(gadget.GadgetId, gadget);
            gadget.transform.SetParent(transform);
            gadget.transform.localPosition = Vector2.zero;
            gadget.transform.right = transform.right;
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
    }
}
