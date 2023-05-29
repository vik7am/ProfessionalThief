using UnityEngine;

namespace ProfessionalThief{
public class PlayerItemCollector : MonoBehaviour
{
    bool safeNearby;
    Safe safe;
    PlayerInventory inventory;

    private void Awake() {
        inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if(!safeNearby)
            return;
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.E)){
            UnlockSafe();
        }
    }

    void UnlockSafe(){
        safe.Unlock();
        Item item = safe.GetItem();
        inventory.AddItemToInventory(item);
        safeNearby = false;
        UIManager.Instance().UpdateItemInfo("Empty");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        safe = other.gameObject.GetComponent<Safe>();
        if(safe == null)
            return;
        if(!safe.IsLocked())
            UIManager.Instance().UpdateItemInfo("Empty");
        else{
            UIManager.Instance().UpdateItemInfo("Press E to Open");
            safeNearby = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        safe = other.gameObject.GetComponent<Safe>();
        if(safe == null)
            return;
        safeNearby = false;
        UIManager.Instance().UpdateItemInfo("");
    }
}
}
