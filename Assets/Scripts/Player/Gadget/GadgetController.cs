using UnityEngine;

namespace ProfessionalThief{
public class GadgetController : MonoBehaviour
{
    [SerializeField] Torch torch;
    [SerializeField] StunGun stunGun;
    [SerializeField] NightVisionGoggles nightVisionGoggles;
    [SerializeField] Animator animator;
    Gadget gadgetEquipped;

    void Start()
    {
        gadgetEquipped = Gadget.EMPTY;
    }

    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
            EquipGadget(Gadget.TORCH);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            EquipGadget(Gadget.STUN_GUN);
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            EquipGadget(Gadget.NIGHT_VISION_GOOGLES);
    }

    void EquipGadget(Gadget gadget){
        if(gadgetEquipped == gadget){
            UnEquipGadget();
            return;
        }
        if(gadgetEquipped != Gadget.EMPTY)
            UnEquipGadget();
        switch(gadget){
            case Gadget.TORCH : torch.Equip(); break;
            case Gadget.STUN_GUN : stunGun.Equip(); animator.SetBool("gun", true); break;
            case Gadget.NIGHT_VISION_GOOGLES : nightVisionGoggles.Equip(); break;
        }
        gadgetEquipped = gadget;
    }

    public void UnEquipGadget(){
        switch(gadgetEquipped){
            case Gadget.TORCH : torch.UnEquip(); break;
            case Gadget.STUN_GUN : stunGun.UnEquip(); animator.SetBool("gun", false); break;
            case Gadget.NIGHT_VISION_GOOGLES : nightVisionGoggles.UnEquip(); break;
        }
        gadgetEquipped = Gadget.EMPTY;
    }

}
}
