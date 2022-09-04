using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] float charge;
    float currentCharge;
    bool equipped;
    bool startRecharge;

    void Start() {
        currentCharge = charge;
    }

    void Update()
    {
        if(startRecharge)
            Increasecharge();
        if(!equipped)
            return;
        GetPlayerInput();
    }

    void Increasecharge(){
        if(currentCharge < charge)
            currentCharge += Time.deltaTime;
        else{
            currentCharge = charge;
            startRecharge = false;
        }
        if(equipped)
            UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentCharge == charge)
                FireGun();
        }
        if(currentCharge == 0){
            if(Input.GetKeyDown(KeyCode.R))
                Recharge();
        }
    }

    void FireGun(){
        currentCharge = 0;
        Instantiate(bullet, transform.position, transform.parent.parent.localRotation);
        UIManager.Instance().UpdateEquippedGadget(Gadget.STUN_GUN);
        UIManager.Instance().UpdateChargeStatus(0);
    }

    public void Recharge(){
        if(inventory.UseBattery())
            startRecharge = true;
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
    }

    public void Equip(){
        equipped = true;
        UIManager.Instance().UpdateEquippedGadget(Gadget.STUN_GUN);
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquip(){
        equipped = false;
        UIManager.Instance().UpdateEquippedGadget(Gadget.Empty);
    }

}
