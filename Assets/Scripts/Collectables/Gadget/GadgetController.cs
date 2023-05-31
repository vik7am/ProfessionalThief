using System;
using UnityEngine;

namespace ProfessionalThief{

    
public class GadgetController : MonoBehaviour
{
    PlayerInventory playerInventory;
    Gadget equippedGadget;
    HudUI hudUI;

    //public static event Action<Gadget> OnGadgetEquipped;

    void Start(){
        equippedGadget = null;
        playerInventory = GetComponent<PlayerInventory>();
        hudUI = UIManager.Instance.Hud;
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
            hudUI.UpdateEquippedGadget(equippedGadget);
            
            //OnGadgetEquipped?.Invoke(null);
        }
        else{
            
            if(!playerInventory.HasGadget(gadgetID)) return;
            
            equippedGadget = playerInventory.GetGadget(gadgetID);
            hudUI.UpdateEquippedGadget(equippedGadget);
            //OnGadgetEquipped(equippedGadget);
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
}
}
