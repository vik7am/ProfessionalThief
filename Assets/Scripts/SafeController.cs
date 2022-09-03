using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    [SerializeField] List<CollectableItem> collectableItems;
    CollectableItem collectableItem;
    bool safeEmpty;
    int itemQuantity;

    void GetCollectableItem(){
        int randomItem = Random.Range(0, collectableItems.Count);
        collectableItem = collectableItems[randomItem];
    }

    void GetCollectableItemQuantity(){
        itemQuantity = Random.Range(collectableItem.GetMinQuantity(),collectableItem.GetMaxQuantity()+1);
    }

    public void OpenSafe(){
        GetCollectableItem();
        GetCollectableItemQuantity();
        safeEmpty = true;
    }

    public int GetItemValue(){
        return collectableItem.GetItemValue();
    }

    public string GetItemName(){
        return collectableItem.GetItemName();
    }

    public int GetItemQuantity(){
        return itemQuantity;
    }

    public bool IsSafeEmpty(){
        return safeEmpty;
    }
}
