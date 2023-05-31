using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief{

    public enum CollectableID {ITEM, GADGET};

    public interface ICollectable{
        public CollectableID GetCollectableID();
    }

public class PlayerInventory : MonoBehaviour
{
    int totalItemValue;
    int availableBattery;

    Dictionary<ItemID, Item> itemList;
    Dictionary<GadgetID, Gadget> gadgetList;

    void Start(){
        totalItemValue = 0;
        availableBattery = 0;
        UIManager.Instance().UpdateAvailableBattery(availableBattery);
        itemList = new Dictionary<ItemID, Item>();
        gadgetList = new Dictionary<GadgetID, Gadget>();
    }

    public void AddItem(Item item){
        ItemID itemID = item.Data.ID;
        if(itemList.TryGetValue(itemID, out Item value)){
            value.AddToStack(item.StackSize);
        }
        else{
            itemList.Add(itemID, item);
        }
        string actionLogText = "Collected " + item.StackSize + " " + item.Data.name;
        UpdateHUD(actionLogText);
    }


    public bool HasItem(ItemID itemID){
        if(itemList.ContainsKey(itemID))
            return true;
        return false;
    }

    public bool HasGadget(GadgetID gadgetID){
        if(gadgetList.ContainsKey(gadgetID))
            return true;
        return false;
    }

    public int GetItemQuantity(ItemID itemID){
        if(HasItem(itemID))
            return itemList[itemID].StackSize;
        return 0;
    }

    public void RemoveItem(ItemID itemID){
        if(HasItem(itemID))
            itemList[itemID].RemoveFromStack(1);
        if(itemList[itemID].StackSize == 0)
            itemList.Remove(itemID);
    }

    // public void AddItem(CollectableItem item, int quantity){
    //     int itemValue = item.GetItemValue();
    //     string itemName = item.GetItemName();
    //     AddUsableItems(item.GetItemType(), quantity);
    //     totalItemValue += itemValue * quantity;
    //     string actionLogText = "Collected " + quantity + " " + itemName;
    //     UpdateHUD(actionLogText);
    // }

    public void AddGadget(Gadget gadget){
        gadgetList.Add(gadget.ID, gadget);
        string actionLogText = "Collected " + gadget.name;
        UpdateHUD(actionLogText);
    }

    public Gadget GetGadget(GadgetID gadgetID){
        return gadgetList[gadgetID];
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
