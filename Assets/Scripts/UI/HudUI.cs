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
    [SerializeField] TextMeshProUGUI gadgetStatus;
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
        gadgetStatus.text = "";
        chargeStatus.gameObject.SetActive(false);
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

    public void UpdateGadgetStatus(Gadget gadget, int value){
        switch(gadget){
            case Gadget.Empty : 
                gadgetStatus.text = "";
                chargeStatus.gameObject.SetActive(false); break;
            case Gadget.STUN_GUN :
                gadgetStatus.text = value.ToString();
                chargeStatus.gameObject.SetActive(true);
                chargeStatus.maxValue = 10; break;
            case Gadget.NIGHT_VISION_GOOGLES :
                gadgetStatus.text = value.ToString();
                chargeStatus.gameObject.SetActive(true);
                chargeStatus.maxValue = 10; break;
        }
    }

    public void UpdateChargeStatus(float value){
        chargeStatus.value = value;
    }
}
