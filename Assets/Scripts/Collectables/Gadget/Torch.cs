using UnityEngine;

namespace ProfessionalThief{
public class Torch : Gadget
{
    [SerializeField] GameObject torchLight;

    public override void Start() {
        base.Start();
        id = GadgetID.TORCH;
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
        hudUI.UpdateChargeStatus(currentCharge);
    }

    void ActivateTorch(){
        if(currentCharge == 0){
            hudUI.UpdateActionLog("Press R to Reload");
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
        hudUI.UpdateEquippedGadget(this);
        //Debug.Log(currentCharge);
        hudUI.UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        DeactivateTorch();
        hudUI.UpdateEquippedGadget(null);
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
        if(playerInventory.UseBattery())
            currentCharge = charge;
        else
            hudUI.UpdateActionLog("Out of Batteries");
        hudUI.UpdateAvailableBattery(playerInventory.GetAvalableBattery());
        hudUI.UpdateChargeStatus(currentCharge);
    }
    }
}