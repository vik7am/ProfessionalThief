using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    bool collectableNearby;
    CollectableItem item;

    void Update()
    {
        if(!collectableNearby)
            return;
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.E)){
            CollectItem();
        }
    }

    void CollectItem(){
        int value = item.GetItemValue();
        UIManager.Instance().UpdateCollectableValue(value);
        Destroy(item.gameObject);
        collectableNearby = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        item = other.GetComponent<CollectableItem>();
        if(item == null)
            return;
        collectableNearby = true;
        UIManager.Instance().UpdateItemInfo(item.GetItemName());
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        item = other.GetComponent<CollectableItem>();
        if(item == null)
            return;
        collectableNearby = false;
        UIManager.Instance().UpdateItemInfo("");
    }
}
