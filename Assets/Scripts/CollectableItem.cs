using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollectableItem : MonoBehaviour
{
    [SerializeField] ItemType itemType;
    [SerializeField] int value;
    [SerializeField] int minQuantity;
    [SerializeField] int maxQuantity;

    public string GetItemName(){
        switch(itemType){
            case ItemType.CASH : return "10$ Cash";
            case ItemType.SILVER_COIN : return "Silver Coin";
            case ItemType.GOLD_COIN : return "Gold Coin";
            case ItemType.BATTERY : return "Battery";
        }
        return "";
    }

    public int GetItemValue(){
        return value;
    }

    public int GetMinQuantity(){
        return minQuantity;
    }

    public int GetMaxQuantity(){
        return maxQuantity;
    }

    public ItemType GetItemType(){
        return itemType;
    }
}
