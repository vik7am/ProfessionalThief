using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProfessionalThief.Player;
using ProfessionalThief.Item;

namespace ProfessionalThief.UI
{
    public class ActionLogUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI actionLogTextUI;

        private void Start()
        {
            RegisterForEvents();
        }

        private void RegisterForEvents(){
            Inventory.onValuableAdded += OnValuableAdded;
            Inventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnGadgetAdded(Gadget gadget){
            actionLogTextUI.text = "Collected " + gadget.name;
        }

        private void OnValuableAdded(Valuable valuable, int quantity){
            actionLogTextUI.text = "Collected " + quantity + " $" +valuable.value + " " + valuable.name;
        }
    }
}
