using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace ProfessionalThief{
public class HudUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValueUI;
    [SerializeField] TextMeshProUGUI itemInfoUI;
    [SerializeField] TextMeshProUGUI actionLogTextUI;
    [SerializeField] TextMeshProUGUI availableBatteryUI;
    [SerializeField] TextMeshProUGUI equippedGadgetUI;
    [SerializeField] Slider chargeStatusUI;
    Coroutine coroutine;
    List<string> actionLog;
    int actionLogCounter = 0;
    Gadget equippedGadget;
    bool gadgetActive;

    void Start()
    {
        actionLog = new List<string>();
        scoreValueUI.text = "$ 0";
        itemInfoUI.text = "";
        actionLogTextUI.text = "";
        gadgetActive = false;
        ToggleGadgetUI(false);
    }

    private void Update() {
        if(gadgetActive)
            UpdateChargeStatusUI();
    }

    private void RegistForEvents(){
        GadgetController.OnGadgetEquipped += OnGadgetEquipped;
        //Gadget.OnGadgetActive += OnGadgetActive;
        //Gadget.OnGadgedRecharged += UpdateChargeStatusUI;
    }

    private void OnGadgetActive(bool status)
    {
        gadgetActive = true;
    }

    private void UpdateChargeStatusUI(){
        chargeStatusUI.value = equippedGadget.CurrentCharge;
    }

    private void OnGadgetEquipped(Gadget gadget)
    {
        if(gadget == null){
            equippedGadget = null;
            ToggleGadgetUI(false);
            return;
        }
        equippedGadget = gadget;
        equippedGadgetUI.text = equippedGadget.Icon;
        chargeStatusUI.maxValue = equippedGadget.Charge;
        ToggleGadgetUI(true);
    }
    
    public void UpdateCollectableValue(int totalTake){
        scoreValueUI.text = "$ " + totalTake;
    }

    public void UpdateItemInfo(string info){
        itemInfoUI.text = info;
    }

    public void UpdateActionLog(string text){
        actionLog.Add(text);
        if(coroutine == null)
            coroutine = StartCoroutine(ShowList());
    }

    IEnumerator ShowList(){
        while(actionLogCounter < actionLog.Count){
            actionLogTextUI.text = actionLog[actionLogCounter];
            yield return new WaitForSeconds(2);
            actionLogTextUI.text = "";
            actionLogCounter++;
            yield return new WaitForSeconds(1);
        }
        coroutine = null;
    }

    public void ToggleGadgetUI(bool status){
        chargeStatusUI.gameObject.SetActive(status);
        availableBatteryUI.gameObject.SetActive(status);
        equippedGadget.gameObject.SetActive(status);
    }

    public void UpdateAvailableBattery(int number){
        availableBatteryUI.text = number.ToString();
        
    }

    public void UpdateChargeStatus(float value){
        chargeStatusUI.value = value;
    }
}
}
