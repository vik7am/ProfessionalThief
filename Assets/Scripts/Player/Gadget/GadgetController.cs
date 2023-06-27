using UnityEngine;

namespace ProfessionalThief.V1{
public class GadgetController : MonoBehaviour
{
    [SerializeField] Torch torch;
    [SerializeField] StunGun stunGun;
    [SerializeField] NightVisionGoggles nightVisionGoggles;
    IGadget gadgetEquipped;

    void Start()
    {
        gadgetEquipped = null;
    }

    void Update()
    {
        GetPlayerInput();
        if(gadgetEquipped != null)
            GetGadgetInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1) && torch.gameObject.activeSelf)
            SwitchGadget(torch);
        else if(Input.GetKeyDown(KeyCode.Alpha2) && stunGun.gameObject.activeSelf)
            SwitchGadget(stunGun);
        else if(Input.GetKeyDown(KeyCode.Alpha3) && nightVisionGoggles.gameObject.activeSelf)
            SwitchGadget(nightVisionGoggles);
    }

    void GetGadgetInput(){
        if(Input.GetKeyDown(KeyCode.Space))
            gadgetEquipped.UseGadget();
        else if(Input.GetKeyDown(KeyCode.R))
            gadgetEquipped.RechargeGadget();
    }

    void SwitchGadget(IGadget gadget){
        if(gadgetEquipped == null){
            gadgetEquipped = gadget;
            gadgetEquipped.EquipGadget();
        }
        else if(gadgetEquipped == gadget){
            gadgetEquipped.UnEquipGadget();
            gadgetEquipped = null;
        }
        else{
            gadgetEquipped.UnEquipGadget();
            gadgetEquipped = gadget;
            gadgetEquipped.EquipGadget();
        }
    }

    public void UnEquipAllGadget(){
        if(gadgetEquipped != null)
            gadgetEquipped.UnEquipGadget();
        gadgetEquipped = null;
    }

    public void UnlockGadget(GadgetType gadgetType){
        switch(gadgetType){
            case GadgetType.TORCH : torch.gameObject.SetActive(true); break;
            case GadgetType.STUN_GUN : stunGun.gameObject.SetActive(true); break;
            case GadgetType.NIGHT_VISION_GOOGLES : nightVisionGoggles.gameObject.SetActive(true); break;
        }
    }
}
}
