using UnityEngine;

namespace ProfessionalThief{
public class StunGun : Gadget
{
    [SerializeField] Bullet bullet;
    [SerializeField] Animator animator;
    bool startRecharge;

    void Start() {
        currentCharge = charge;
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
            UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    void FireGun(){
        currentCharge = 0;
        Instantiate(bullet, transform.position, transform.parent.parent.localRotation);
        UIManager.Instance().UpdateChargeStatus(0);
    }

    public override void Equip(){
        equipped = true;
        animator.SetBool("gun", true);
        UIManager.Instance().UpdateEquippedGadget(GadgetType.STUN_GUN, charge);
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public override void UnEquip(){
        equipped = false;
        animator.SetBool("gun", false);
        UIManager.Instance().UpdateEquippedGadget(GadgetType.EMPTY, 0);
    }

    public override void Use(){
        if(currentCharge == charge)
            FireGun();
        else
            UIManager.Instance().UpdateActionLog("Press R to Reload");
    }

    public override void Recharge(){
        if(currentCharge > 0)
            return;
        if(inventory.UseBattery())
            startRecharge = true;
        else
            UIManager.Instance().UpdateActionLog("Out of Batteries");
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
    }
}
}
