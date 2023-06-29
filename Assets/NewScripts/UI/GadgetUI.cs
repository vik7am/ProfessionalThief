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
            gadgetNameTextUI.text = gadget.Icon;
            chargeLeftUI.maxValue = gadget.MaxCharge;
            chargeLeftUI.value = equippedGadget.Currentcharge;
        }

        public void OnGadgetUnEquip(){
            equippedGadget = null;
        }

        private void Update(){
            if(equippedGadget){
                chargeLeftUI.value = equippedGadget.Currentcharge;
            }
        }
    }
}
