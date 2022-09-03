using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI itemInfo;
    [SerializeField] TextMeshProUGUI actionLogText;
    Coroutine coroutine;
    List<string> actionLog;
    int actionLogCounter = 0;

    void Start()
    {
        actionLog = new List<string>();
        scoreValue.text = "$ 0";
        itemInfo.text = "";
        actionLogText.text = "";
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
}
