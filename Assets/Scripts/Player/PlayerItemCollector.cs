using UnityEngine;

namespace ProfessionalThief{
public class PlayerItemCollector : MonoBehaviour
{
    bool collectableNearby;
    SafeController safe;
    PlayerInventory inventory;

    private void Awake() {
        inventory = GetComponent<PlayerInventory>();
    }

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
        CollectableItem collectableItem = safe.OpenSafe();
        int quantity = safe.GetItemQuantity();
        inventory.AddItem(collectableItem, quantity);
        collectableNearby = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        safe = other.gameObject.GetComponent<SafeController>();
        if(safe == null)
            return;
        if(safe.IsSafeEmpty())
            UIManager.Instance().UpdateItemInfo("Empty");
        else{
            UIManager.Instance().UpdateItemInfo("Press E to Open");
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
}
