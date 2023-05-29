using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief{

public class PlayerInventory : MonoBehaviour
{
    int totalItemValue;
    int availableBattery;

    Dictionary<ItemID, Item> playerItemList;

    void Start(){
        totalItemValue = 0;
        availableBattery = 0;
        UIManager.Instance().UpdateAvailableBattery(availableBattery);
        playerItemList = new Dictionary<ItemID, Item>();
    }

    public void AddItemToInventory(Item item){
        ItemID itemID = item.Data.ID;
        if(playerItemList.TryGetValue(itemID, out Item value)){
            value.AddToStack(item.StackSize);
        }
        else{
            playerItemList.Add(itemID, item);
        }
        string actionLogText = "Collected " + item.StackSize + " " + item.Data.name;
        UpdateHUD(actionLogText);
    }

    public bool HasItem(ItemID itemID){
        if(playerItemList.ContainsKey(itemID))
            return true;
        return false;
    }

    public int GetItemQuantity(ItemID itemID){
        if(HasItem(itemID))
            return playerItemList[itemID].StackSize;
        return 0;
    }

    public void RemoveItem(ItemID itemID){
        if(HasItem(itemID))
            playerItemList[itemID].RemoveFromStack(1);
        if(playerItemList[itemID].StackSize == 0)
            playerItemList.Remove(itemID);
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
        // if(itemType == ItemType.BATTERY){
        //     availableBattery += quantity;
        //     UIManager.Instance().UpdateAvailableBattery(availableBattery);
        // }
    }

    public bool UseBattery(){
        if(HasItem(ItemID.BATTERY)){
            RemoveItem(ItemID.BATTERY);
            return true;
        }
        else
            return false;
    }

    public int GetAvalableBattery(){
        return GetItemQuantity(ItemID.BATTERY);
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
