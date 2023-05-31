using System;
using UnityEngine;

namespace ProfessionalThief{

    public enum GadgetID {TORCH, STUN_GUN, NIGHT_VISION_GOGGLES};
public class GadgetController : MonoBehaviour
{
    [SerializeField] Torch torch;
    [SerializeField] StunGun stunGun;
    [SerializeField] NightVisionGoggles nightVisionGoggles;
    PlayerInventory playerInventory;
    Gadget equippedGadget;

    public static event Action<Gadget> OnGadgetEquipped;

    void Start(){
        equippedGadget = null;
    }

    void Update()
    {
        GetPlayerInput();
        if(equippedGadget != null)
            GetGadgetInput();
    }

    private void ToggleGadget(GadgetID gadgetID){
        if(equippedGadget != null && gadgetID == equippedGadget.ID){
            equippedGadget = null;
            OnGadgetEquipped?.Invoke(null);
        }
        else{
            if(!playerInventory.HasGadget(gadgetID)) return;
            equippedGadget = playerInventory.GetGadget(gadgetID);
            OnGadgetEquipped(equippedGadget);
        }
    }

        void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ToggleGadget(GadgetID.TORCH);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            ToggleGadget(GadgetID.STUN_GUN);
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            ToggleGadget(GadgetID.NIGHT_VISION_GOGGLES);
    }

    void GetGadgetInput(){
        if(Input.GetKeyDown(KeyCode.Space))
            equippedGadget.Use();
        else if(Input.GetKeyDown(KeyCode.R))
            equippedGadget.Recharge();
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
