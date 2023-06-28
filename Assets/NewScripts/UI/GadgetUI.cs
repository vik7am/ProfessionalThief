using System;
using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Items;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ProfessionalThief.UI
{
    public class GadgetUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gadgetNameTextUI;
        [SerializeField] private Slider chargeLeftUI;
        private Gadget equippedGadget;

        public void OnGadgetEquip(Gadget gadget){
            equippedGadget = gadget;
            gadgetNameTextUI.text = gadget.icon;
            chargeLeftUI.maxValue = gadget.maxCharge;
            chargeLeftUI.value = equippedGadget.currentCharge;
        }

        public void OnGadgetUnEquip(){
            equippedGadget = null;
        }

        private void Update(){
            if(equippedGadget && equippedGadget.IsActive){
                chargeLeftUI.value = equippedGadget.currentCharge;
            }
        }
    }
}
