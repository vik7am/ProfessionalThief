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
                Reload();
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

    public void Reload(){
        if(inventory.UseBattery())
            currentCharge = charge;
        UIManager.Instance().UpdateGadgetStatus(Gadget.NIGHT_VISION_GOOGLES, inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void Equip(){
        equipped = true;
        UIManager.Instance().UpdateGadgetStatus(Gadget.NIGHT_VISION_GOOGLES, inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquip(){
        equipped = false;
        DeactivateNightVision();
        UIManager.Instance().UpdateGadgetStatus(Gadget.Empty, inventory.GetAvalableBattery());
    }
}
