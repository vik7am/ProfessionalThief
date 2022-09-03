using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{CASH, SILVER_COIN, GOLD_COIN}

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
}
