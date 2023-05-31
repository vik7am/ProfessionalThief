using UnityEngine;

namespace ProfessionalThief{
public class NightVisionGoggles : Gadget
{
    [SerializeField] GameObject greenLight;

    void Start() {
        currentCharge = charge;
        hudUI = UIManager.Instance.Hud;
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
            DeactivateNightVision();
        }
        hudUI.UpdateChargeStatus(currentCharge);
    }

    void ActivateNightVision(){
        if(currentCharge == 0){
            hudUI.UpdateActionLog("Press R to Reload");
            return;
        }
        active = true;
        greenLight.SetActive(true);
    }

    void DeactivateNightVision(){
        active = false;
        greenLight.SetActive(false);
    }

    public override void Equip(){
        equipped = true;
        hudUI.UpdateEquippedGadget(this);
        hudUI.UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        DeactivateNightVision();
        hudUI.UpdateEquippedGadget(null);
    }

    public override void Use(){
        if(active)
            DeactivateNightVision();
        else
            ActivateNightVision();
    }

    public override void Recharge(){
        if(currentCharge >= charge)
            return;
        if(inventory.UseBattery())
            currentCharge = charge;
        else
            hudUI.UpdateActionLog("Out of Batteries");
        hudUI.UpdateAvailableBattery(inventory.GetAvalableBattery());
        hudUI.UpdateChargeStatus(currentCharge);
        }
    }
}
