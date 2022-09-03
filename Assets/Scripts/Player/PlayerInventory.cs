using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{CASH, SILVER_COIN, GOLD_COIN, BATTERY}

public class PlayerInventory : MonoBehaviour
{
    int totalTake;

    void Start(){
        totalTake = 0;
    }

    public void AddItem(CollectableItem item, int quantity){
        int itemValue = item.GetItemValue();
        string itemName = item.GetItemName();
        totalTake += itemValue * quantity;
        string actionLogText = "Collected " + quantity + " " + itemName;
        UpdateHUD(actionLogText);
    }

    void UpdateHUD(string actionLogText){
        UIManager.Instance().UpdateCollectableValue(totalTake);
        UIManager.Instance().UpdateActionLog(actionLogText);
        UIManager.Instance().UpdateItemInfo("");
    }
}
