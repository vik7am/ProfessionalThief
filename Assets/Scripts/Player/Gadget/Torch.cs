using UnityEngine;

namespace ProfessionalThief{
public class Torch : MonoBehaviour
{
    [SerializeField] GameObject torchLight;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] float charge;
    float currentCharge;
    bool equipped;
    bool active;

    void Start() {
        currentCharge = charge;
    }

    void Update()
    {
        if(!equipped)
            return;
        GetPlayerInput();
        if(active)
            ReduceCharge();
    }

    void ReduceCharge(){
        if(currentCharge > 0)
            currentCharge -= Time.deltaTime;
        else{
            currentCharge = 0;
            DeactivateTorch();
        }
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }
        
    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(active)
                DeactivateTorch();
            else
                ActivateTorch();
        }
        if(currentCharge < charge){
            if(Input.GetKeyDown(KeyCode.R))
                Recharge();
        }
    }

    void ActivateTorch(){
        if(currentCharge == 0)
            return;
        active = true;
        torchLight.SetActive(true);
    }

    void DeactivateTorch(){
        active = false;
        torchLight.SetActive(false);
    }

    public void Recharge(){
        if(inventory.UseBattery())
            currentCharge = charge;
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void Equip(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(Gadget.TORCH);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquip(){
        equipped = false;
        DeactivateTorch();
        UIManager.Instance().UpdateEquippedGadget(Gadget.EMPTY);
    }
}
}