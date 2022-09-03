using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    bool collectableNearby;
    SafeController safe;

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
        safe.OpenSafe();
        int value = safe.GetItemValue();
        int quantity = safe.GetItemQuantity();
        string itemName = safe.GetItemName();
        string actionLogText = "Collected " + quantity + " " + itemName;
        UIManager.Instance().UpdateCollectableValue(quantity * value);
        UIManager.Instance().UpdateActionLog(actionLogText);
        collectableNearby = false;
        UIManager.Instance().UpdateItemInfo("");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        safe = other.gameObject.GetComponent<SafeController>();
        if(safe == null)
            return;
        if(safe.IsSafeEmpty())
            UIManager.Instance().UpdateItemInfo("Safe Empty");
        else{
            UIManager.Instance().UpdateItemInfo("Open Safe");
            collectableNearby = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        safe = other.gameObject.GetComponent<SafeController>();
        if(safe == null)
            return;
        collectableNearby = false;
        UIManager.Instance().UpdateItemInfo("");
    }
}
