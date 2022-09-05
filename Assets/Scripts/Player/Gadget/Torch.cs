using UnityEngine;

namespace ProfessionalThief{
public class Torch : MonoBehaviour, IGadget
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

    public void EquipGadget(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(Gadget.TORCH);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquipGadget(){
        equipped = false;
        DeactivateTorch();
        UIManager.Instance().UpdateEquippedGadget(Gadget.EMPTY);
    }

    public void UseGadget(){
        if(active)
                DeactivateTorch();
            else
                ActivateTorch();
    }

    public void RechargeGadget(){
        if(currentCharge < charge)
                Recharge();
        
    }
}
}