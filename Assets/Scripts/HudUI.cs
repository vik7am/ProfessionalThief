using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI itemInfo;
    int totalCollectableValue;

    void Start()
    {
        totalCollectableValue = 0;
        scoreValue.text = "$ 0";
        itemInfo.text = "";
    }

    public void UpdateCollectableValue(int value)
    {
        totalCollectableValue += value;
        scoreValue.text = "$ " + totalCollectableValue;
    }

    public void UpdateItemInfo(string info){
        itemInfo.text = info;
    }
}
