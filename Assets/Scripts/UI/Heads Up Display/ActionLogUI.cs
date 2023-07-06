using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProfessionalThief.Player;
using ProfessionalThief.Items;

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
        }

        private void OnEnable() {
            PlayerInventory.onValuableAdded += OnValuableAdded;
            PlayerInventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnDisable() {
            PlayerInventory.onValuableAdded -= OnValuableAdded;
            PlayerInventory.onGadgetAdded -= OnGadgetAdded;
        }

        private void OnGadgetAdded(Gadget gadget){
            AddLogToQueue("Collected " + gadget.Name);
        }

        private void OnValuableAdded(Valuable valuable, int quantity){
            AddLogToQueue("Collected " + quantity + " $" +valuable.Value + " " + valuable.Name);
        }

        private void AddLogToQueue(string text){
            actionLogQueue.Enqueue(text);
            if(logCoroutine == null){
                logCoroutine = StartCoroutine(ShowActionLogCoroutine());
            }
        }

        private IEnumerator ShowActionLogCoroutine(){
            while(actionLogQueue.Count>0){
                actionLogTextUI.text = actionLogQueue.Dequeue();
                yield return new WaitForSeconds(logTextVisibilityDuration);
            }
            actionLogTextUI.text = "";
            logCoroutine = null;
        }
    }
}
