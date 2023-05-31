using UnityEngine;

namespace ProfessionalThief{
public class PlayerItemCollector : MonoBehaviour
{
    bool safeNearby;
    Safe safe;
    PlayerInventory inventory;
    private HudUI hudUI;

    private void Awake() {
        inventory = GetComponent<PlayerInventory>();
    }

    private void Start() {
        hudUI = UIManager.Instance.Hud;
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
        ICollectable collectable = safe.GetCollectable();
        CollectableID id = collectable.GetCollectableID();
        if(id == CollectableID.ITEM){
            inventory.AddItem((Item)collectable);
        }
        else if(id == CollectableID.GADGET){
            inventory.AddGadget((Gadget)collectable);
        }
        safeNearby = false;
        hudUI.UpdateItemInfo("Empty");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        safe = other.gameObject.GetComponent<Safe>();
        if(safe == null)
            return;
        if(!safe.IsLocked())
            hudUI.UpdateItemInfo("Empty");
        else{
            hudUI.UpdateItemInfo("Press E to Open");
            safeNearby = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        safe = other.gameObject.GetComponent<Safe>();
        if(safe == null)
            return;
        safeNearby = false;
        hudUI.UpdateItemInfo("");
    }
}
}
