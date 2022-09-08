using UnityEngine;

namespace ProfessionalThief{
public class StunGun : MonoBehaviour, IGadget
{
    [SerializeField] Bullet bullet;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] float charge;
    [SerializeField] Animator animator;
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
        UIManager.Instance().UpdateEquippedGadget(GadgetType.STUN_GUN);
        UIManager.Instance().UpdateChargeStatus(0);
    }

    public void Recharge(){
        if(inventory.UseBattery())
            startRecharge = true;
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
    }

    public void EquipGadget(){
        equipped = true;
        animator.SetBool("gun", true);
        UIManager.Instance().UpdateEquippedGadget(GadgetType.STUN_GUN);
        UIManager.Instance().UpdateAvailableBattery(inventory.GetAvalableBattery());
        UIManager.Instance().UpdateChargeStatus(currentCharge);
    }

    public void UnEquipGadget(){
        equipped = false;
        animator.SetBool("gun", false);
        UIManager.Instance().UpdateEquippedGadget(GadgetType.EMPTY);
    }

    public void UseGadget(){
        if(currentCharge == charge)
                FireGun();
    }

    public void RechargeGadget(){
        if(currentCharge == 0)
                Recharge();
    }

}
}
