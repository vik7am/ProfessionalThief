using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    [SerializeField] List<CollectableItem> collectableItems;
    CollectableItem collectableItem;
    bool safeEmpty;
    int itemQuantity;

    void SpawnCollectableItem(){
        int randomItem = Random.Range(0, collectableItems.Count);
        collectableItem = collectableItems[randomItem];
    }

    void SetCollectableItemQuantity(){
        itemQuantity = Random.Range(collectableItem.GetMinQuantity(),collectableItem.GetMaxQuantity()+1);
    }

    public CollectableItem OpenSafe(){
        SpawnCollectableItem();
        SetCollectableItemQuantity();
        safeEmpty = true;
        return collectableItem;
    }

    public int GetItemQuantity(){
        return itemQuantity;
    }

    public bool IsSafeEmpty(){
        return safeEmpty;
    }
}
