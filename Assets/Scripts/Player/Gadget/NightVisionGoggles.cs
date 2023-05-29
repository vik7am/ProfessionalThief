using UnityEngine;

namespace ProfessionalThief{
public class NightVisionGoggles : IGadget
{
    [SerializeField] GameObject greenLight;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] int charge;
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
            DeactivateNightVision();
        }
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    void ActivateNightVision(){
        if(currentCharge == 0){
            UIManager.Instance().UpdateActionLog("Press R to Reload");
            return;
        }
        active = true;
        greenLight.SetActive(true);
    }

    void DeactivateNightVision(){
        active = false;
        greenLight.SetActive(false);
    }

    public void Recharge(){
        if(inventory.UseBattery())
            currentCharge = charge;
        else
            UIManager.Instance().UpdateActionLog("Out of Batteries");
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public override void EquipGadget(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(GadgetType.NIGHT_VISION_GOOGLES, charge);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public override void UnEquipGadget(){
        equipped = false;
        DeactivateNightVision();
        UIManager.Instance().UpdateEquippedGadget(GadgetType.EMPTY, 0);
    }

    public override void UseGadget(){
        if(active)
            DeactivateNightVision();
        else
            ActivateNightVision();
    }

    public override void RechargeGadget(){
        if(currentCharge < charge){
            Recharge();
        }
    }
    }
}
