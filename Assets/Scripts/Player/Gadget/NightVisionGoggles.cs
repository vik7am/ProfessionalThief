using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVisionGoggles : MonoBehaviour
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
        GetPlayerInput();
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
        
    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(active)
                DeactivateNightVision();
            else
                ActivateNightVision();
        }
        if(currentCharge < charge){
            if(Input.GetKeyDown(KeyCode.R))
                Recharge();
        }
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

    public void Equip(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(Gadget.NIGHT_VISION_GOOGLES);
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquip(){
        equipped = false;
        DeactivateNightVision();
        UIManager.Instance().UpdateEquippedGadget(Gadget.Empty);
    }
}
