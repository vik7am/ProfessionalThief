using UnityEngine;

namespace ProfessionalThief{
public class Torch : Gadget
{
    [SerializeField] GameObject torchLight;

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
        if(currentCharge == 0){
            UIManager.Instance().UpdateActionLog("Press R to Reload");
            return;
        }
        active = true;
        torchLight.SetActive(true);
    }

    void DeactivateTorch(){
        active = false;
        torchLight.SetActive(false);
    }

    public override void Equip(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(GadgetType.TORCH, charge);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        DeactivateTorch();
        UIManager.Instance().UpdateEquippedGadget(GadgetType.EMPTY, 0);
    }

    public override void Use(){
        if(active)
                DeactivateTorch();
            else
                ActivateTorch();
    }

    public override void Recharge(){
        if(currentCharge >= charge)
            return;
        if(inventory.UseBattery())
            currentCharge = charge;
        else
            UIManager.Instance().UpdateActionLog("Out of Batteries");
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }
    }
}