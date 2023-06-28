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
            HandlePlayerInput();
        }

        public void AddGadget(Gadget gadget){
            gadgetList.Add(gadget.Id, gadget);
        }

        private void HandlePlayerInput()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                ToggleGadget(ItemId.GADGET_TORCH);
            }
        }

        private void ToggleGadget(ItemId itemId){
            if(!gadgetList.ContainsKey(itemId)) return;
            if(equippedGadget){
                if(equippedGadget.Id == itemId){
                    UnEquipGadget();
                }
                else{
                    UnEquipGadget();
                    EquipGadget(itemId);
                }
            }
            else{
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
