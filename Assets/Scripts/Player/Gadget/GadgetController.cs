using System;
using UnityEngine;

namespace ProfessionalThief{
public class GadgetController : MonoBehaviour
{
    [SerializeField] Torch torch;
    [SerializeField] StunGun stunGun;
    [SerializeField] NightVisionGoggles nightVisionGoggles;
    PlayerInventory playerInventory;
    Gadget gadget;

    void Start()
    {
        gadget = null;
    }

    void Update()
    {
        GetPlayerInput();
        if(gadget != null)
            GetGadgetInput();
    }

    private void ToggleGadget(ItemID itemID){
        if(itemID == GetCurrentItemID())
            gadget.UnEquip();
        else
            gadget.Equip();
        
    }

        private ItemID GetCurrentItemID()
        {
            return gadget.GetComponent<Item>().Data.ID;
        }

        void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
            ToggleGadget(ItemID.TORCH);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            ToggleGadget(ItemID.STUN_GUN);
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            ToggleGadget(ItemID.NIGHT_VISION_GOGGLES);
    }

    void GetGadgetInput(){
        if(Input.GetKeyDown(KeyCode.Space))
            gadget.Use();
        else if(Input.GetKeyDown(KeyCode.R))
            gadget.Recharge();
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
