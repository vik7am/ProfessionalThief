using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI itemInfo;
    [SerializeField] TextMeshProUGUI actionLogText;
    [SerializeField] TextMeshProUGUI availableBattery;
    [SerializeField] TextMeshProUGUI equippedGadget;
    [SerializeField] Slider chargeStatus;
    Coroutine coroutine;
    List<string> actionLog;
    int actionLogCounter = 0;

    void Start()
    {
        actionLog = new List<string>();
        scoreValue.text = "$ 0";
        itemInfo.text = "";
        actionLogText.text = "";
        ToggleGadgetUI(false);
    }

    public void UpdateCollectableValue(int totalTake){
        scoreValue.text = "$ " + totalTake;
    }

    public void UpdateItemInfo(string info){
        itemInfo.text = info;
    }

    public void UpdateActionLog(string text){
        actionLog.Add(text);
        if(coroutine == null)
            coroutine = StartCoroutine(ShowList());
    }

    IEnumerator ShowList(){
        while(actionLogCounter < actionLog.Count){
            actionLogText.text = actionLog[actionLogCounter];
            yield return new WaitForSeconds(2);
            actionLogText.text = "";
            actionLogCounter++;
            yield return new WaitForSeconds(1);
        }
        coroutine = null;
    }

    public void UpdateEquippedGadget(Gadget gadget){
        switch(gadget){
            case Gadget.EMPTY : 
                ToggleGadgetUI(false); break;
            case Gadget.TORCH :
                ToggleGadgetUI(true);
                equippedGadget.text = "T";
                chargeStatus.maxValue = 20; break;
            case Gadget.STUN_GUN :
                ToggleGadgetUI(true);
                equippedGadget.text = "G";
                chargeStatus.maxValue = 1; break;
            case Gadget.NIGHT_VISION_GOOGLES :
                ToggleGadgetUI(true);
                equippedGadget.text = "N";
                chargeStatus.maxValue = 10; break;
        }
    }

    public void ToggleGadgetUI(bool status){
        chargeStatus.gameObject.SetActive(status);
        availableBattery.gameObject.SetActive(status);
        equippedGadget.gameObject.SetActive(status);
    }

    public void UpdateAvailableBattery(int number){
        availableBattery.text = number.ToString();
        
    }

    public void UpdateChargeStatus(float value){
        chargeStatus.value = value;
    }
}
