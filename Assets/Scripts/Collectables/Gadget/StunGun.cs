using UnityEngine;

namespace ProfessionalThief{
public class StunGun : Gadget
{
    [SerializeField] Bullet bullet;
    [SerializeField] Animator animator;
    bool startRecharge;

    public override void Start() {
        base.Start();
        id = GadgetID.STUN_GUN;
    }

    void Update()
    {
        if(startRecharge)
            Increasecharge();
    }

    void Increasecharge(){
        if(currentCharge < charge)
            currentCharge += Time.deltaTime;
        else{
            currentCharge = charge;
            startRecharge = false;
        }
        if(equipped)
            hudUI.UpdateChargeStatus(currentCharge);
    }

    void FireGun(){
        currentCharge = 0;
        Instantiate(bullet, transform.position, transform.parent.parent.localRotation);
        hudUI.UpdateChargeStatus(0);
    }

    public override void Equip(){
        equipped = true;
        animator.SetBool("gun", true);
        hudUI.UpdateEquippedGadget(this);
        hudUI.UpdateAvailableBattery(inventory.GetAvalableBattery());
        hudUI.UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        animator.SetBool("gun", false);
        hudUI.UpdateEquippedGadget(null);
    }

    public override void Use(){
        if(currentCharge == charge)
            FireGun();
        else
            hudUI.UpdateActionLog("Press R to Reload");
    }

    public override void Recharge(){
        if(currentCharge > 0)
            return;
        if(inventory.UseBattery())
            startRecharge = true;
        else
            hudUI.UpdateActionLog("Out of Batteries");
        hudUI.UpdateAvailableBattery(inventory.GetAvalableBattery());
    }
}
}
