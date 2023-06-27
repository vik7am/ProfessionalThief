using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProfessionalThief.Player;
using ProfessionalThief.Chest;

namespace ProfessionalThief.UI
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactionPanel;
        [SerializeField] private TextMeshProUGUI interactionMessage;
        
        private void Start(){
            RegisterForEvents();
        }

        private void RegisterForEvents(){
            Interactor.onNearInteractableItem += ToggleInteractionUI;
        }

        private void ToggleInteractionUI(IInteractableItem item)
        {
            if(item == null){
                interactionPanel.SetActive(false);
                return;
            }
            interactionPanel.SetActive(true);
            interactionMessage.text = "Press E to collect item from chest";
        }
    }
}
