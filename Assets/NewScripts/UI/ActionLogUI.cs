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
        private Queue<string> actionLogQueue;
        [SerializeField] float logTextVisibilityDuration;
        private Coroutine logCoroutine;
        private string logText;

        private void Awake() {
            actionLogQueue = new Queue<string>();
        }

        private void Start(){
            actionLogTextUI.text = "";
            RegisterForEvents();
        }

        private void RegisterForEvents(){
            Inventory.onValuableAdded += OnValuableAdded;
            Inventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnGadgetAdded(Gadget gadget){
            AddLogToQueue("Collected " + gadget.name);
        }

        private void OnValuableAdded(Valuable valuable, int quantity){
            AddLogToQueue("Collected " + quantity + " $" +valuable.value + " " + valuable.name);
        }

        private void AddLogToQueue(string text){
            actionLogQueue.Enqueue(text);
            if(logCoroutine == null){
                logCoroutine = StartCoroutine(ShowActionLogCoroutine());
            }
        }

        IEnumerator ShowActionLogCoroutine(){
            while(actionLogQueue.Count>0){
                actionLogTextUI.text = actionLogQueue.Dequeue();
                yield return new WaitForSeconds(logTextVisibilityDuration);
            }
            actionLogTextUI.text = "";
            logCoroutine = null;
        }
    }
}
