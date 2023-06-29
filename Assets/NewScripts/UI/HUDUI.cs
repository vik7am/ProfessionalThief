using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using ProfessionalThief.Chest;

namespace ProfessionalThief.UI
{
    public class HUDUI : MonoBehaviour
    {
        [SerializeField] private GadgetUI gadgetUI;
        [SerializeField] private ActionLogUI actionLogUI;
        [SerializeField] private InteractionUI interactionUI;
        [SerializeField] private TextMeshProUGUI totalTakeTextUI;

        private void Start(){
            gadgetUI.gameObject.SetActive(false);
            interactionUI.gameObject.SetActive(false);
        }

        private void OnEnable() {
            Inventory.onTotalTakeUpdated += OnTotalTakeUpdated;
            GadgetController.onGadgetEquip += OnGadgetEquip;
            GadgetController.onGadgetUnEquip += OnGadgetUnEquip;
            Interactor.onNearInteractableItem += ToggleInteractionUI;
        }

        private void OnDisable() {
            Inventory.onTotalTakeUpdated -= OnTotalTakeUpdated;
            GadgetController.onGadgetEquip -= OnGadgetEquip;
            GadgetController.onGadgetUnEquip -= OnGadgetUnEquip;
            Interactor.onNearInteractableItem -= ToggleInteractionUI;

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

        public void ToggleInteractionUI(IInteractableItem item){
            if(item == null){
                interactionUI.gameObject.SetActive(false);
                return;
            }
            interactionUI.gameObject.SetActive(true);
            interactionUI.SetInteractionMessage(item);
            
            
        }
    }
}
