using UnityEngine;

namespace ProfessionalThief{
public class NightVisionGoggles : MonoBehaviour, IGadget
{
    [SerializeField] GameObject greenLight;
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
            DeactivateNightVision();
        }
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    void ActivateNightVision(){
        if(currentCharge == 0)
            return;
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
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void EquipGadget(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(Gadget.NIGHT_VISION_GOOGLES);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquipGadget(){
        equipped = false;
        DeactivateNightVision();
        UIManager.Instance().UpdateEquippedGadget(Gadget.EMPTY);
    }

    public void UseGadget(){
        if(active)
            DeactivateNightVision();
        else
            ActivateNightVision();
    }

    public void RechargeGadget(){
        if(currentCharge < charge){
            Recharge();
        }
    }
}
}
