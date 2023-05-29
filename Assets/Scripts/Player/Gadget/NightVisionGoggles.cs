using UnityEngine;

namespace ProfessionalThief{
public class NightVisionGoggles : Gadget
{
    [SerializeField] GameObject greenLight;

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

    public void RechargeIt(){
        
    }

    public override void Equip(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(GadgetType.NIGHT_VISION_GOOGLES, charge);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        DeactivateNightVision();
        UIManager.Instance().UpdateEquippedGadget(GadgetType.EMPTY, 0);
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
            UIManager.Instance().UpdateActionLog("Out of Batteries");
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
        }
    }
}
