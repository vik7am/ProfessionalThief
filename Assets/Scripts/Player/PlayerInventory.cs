using UnityEngine;

namespace ProfessionalThief{
public class PlayerInventory : MonoBehaviour
{
    int totalItemValue;
    int availableBattery;

    void Start(){
        totalItemValue = 0;
        availableBattery = 0;
        UIManager.Instance().UpdateAvailableBattery(availableBattery);
    }

    public void AddItem(CollectableItem item, int quantity){
        int itemValue = item.GetItemValue();
        string itemName = item.GetItemName();
        AddUsableItems(item.GetItemType(), quantity);
        totalItemValue += itemValue * quantity;
        string actionLogText = "Collected " + quantity + " " + itemName;
        UpdateHUD(actionLogText);
    }

    void AddUsableItems(ItemType itemType , int quantity){
        if(itemType == ItemType.BATTERY){
            availableBattery += quantity;
            UIManager.Instance().UpdateAvailableBattery(availableBattery);
        }
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
        UIManager.Instance().UpdateCollectableValue(totalItemValue);
        UIManager.Instance().UpdateActionLog(actionLogText);
        UIManager.Instance().UpdateItemInfo("");
    }

    public int GetTotalItemValue(){
        return totalItemValue;
    }
}
}
