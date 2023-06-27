using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ProfessionalThief.Player;

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
        }

        private void OnTotalTakeUpdated(int amountInDollar){
            totalTakeTextUI.text = "$ " + amountInDollar;
        }
    }
}
