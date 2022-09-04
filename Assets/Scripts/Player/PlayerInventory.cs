using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{CASH, SILVER_COIN, GOLD_COIN, BATTERY}

public class PlayerInventory : MonoBehaviour
{
    int totalTake;
    int availableBattery;

    void Start(){
        totalTake = 0;
        availableBattery = 5;
    }

    public void AddItem(CollectableItem item, int quantity){
        int itemValue = item.GetItemValue();
        string itemName = item.GetItemName();
        AddUsableItems(item.GetItemType(), quantity);
        totalTake += itemValue * quantity;
        string actionLogText = "Collected " + quantity + " " + itemName;
        UpdateHUD(actionLogText);
    }

    void AddUsableItems(ItemType itemType , int quantity){
        if(itemType == ItemType.BATTERY)
            availableBattery += quantity;
    }

    public bool UseBattery(){
        if(availableBattery > 0){
            availableBattery--;
            return true;
        }
        else
            return false;
    }

    public int GetAvalableBattery(){
        return availableBattery;
    }

    void UpdateHUD(string actionLogText){
        UIManager.Instance().UpdateCollectableValue(totalTake);
        UIManager.Instance().UpdateActionLog(actionLogText);
        UIManager.Instance().UpdateItemInfo("");
    }
}
