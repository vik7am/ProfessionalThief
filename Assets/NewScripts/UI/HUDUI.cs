using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ProfessionalThief.Player;
using ProfessionalThief.Items;

namespace ProfessionalThief.UI
{
    public class HUDUI : UserInterface
    {
        [SerializeField] private GadgetUI gadgetUI;
        [SerializeField] private ActionLogUI actionLogUI;
        [SerializeField] private InteractionUI interactionUI;
        [SerializeField] private TextMeshProUGUI totalTakeTextUI;

        private void Start(){
            RegisterForEvents();
        }

        private void RegisterForEvents(){
            Inventory.onTotalTakeUpdated += OnTotalTakeUpdated;
            GadgetController.onGadgetEquip += OnGadgetEquip;
            GadgetController.onGadgetUnEquip += OnGadgetUnEquip;
            gadgetUI.gameObject.SetActive(false);
        }

        private void OnTotalTakeUpdated(int amountInDollar){
            totalTakeTextUI.text = "$ " + amountInDollar;
        }

        public void OnGadgetEquip(Gadget gadget){
            gadgetUI.gameObject.SetActive(true);
            gadgetUI.OnGadgetEquip(gadget);

        }

        public void OnGadgetUnEquip(){
            gadgetUI.OnGadgetUnEquip();
            gadgetUI.gameObject.SetActive(false);
        }
    }
}
