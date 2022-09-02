using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    enum ItemType{CASH, SILVER_COIN, GOLD_COIN}

    [SerializeField]ItemType itemType;
    [SerializeField]int value;

    public string GetItemName(){
        switch(itemType){
            case ItemType.CASH : return "Cash";
            case ItemType.SILVER_COIN : return "Silver Coin";
            case ItemType.GOLD_COIN : return "Gold Coin";
        }
        return "";
    }

    public int GetItemValue(){
        return value;
    }
}
