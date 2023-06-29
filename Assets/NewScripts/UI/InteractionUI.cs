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

        public void SetInteractionMessage(IInteractableItem item){
            interactionMessage.text = item.InteractionMessage();
        }
    }
}
