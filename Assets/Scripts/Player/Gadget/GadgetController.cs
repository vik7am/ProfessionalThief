using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gadget {Empty, STUN_GUN, NIGHT_VISION_GOOGLES};

public class GadgetController : MonoBehaviour
{
    [SerializeField] StunGun stunGun;
    [SerializeField] NightVisionGoggles nightVisionGoggles;
    Gadget gadgetEquipped;

    void Start()
    {
        gadgetEquipped = Gadget.Empty;
    }

    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
            EquipGadget(Gadget.STUN_GUN);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            EquipGadget(Gadget.NIGHT_VISION_GOOGLES);
    }

    void EquipGadget(Gadget gadget){
        if(gadgetEquipped == gadget){
            UnEquipGadget();
            return;
        }
        if(gadgetEquipped != Gadget.Empty)
            UnEquipGadget();
        switch(gadget){
            case Gadget.STUN_GUN : stunGun.Equip(); break;
            case Gadget.NIGHT_VISION_GOOGLES : nightVisionGoggles.Equip(); break;
        }
        gadgetEquipped = gadget;
    }

    public void UnEquipGadget(){
        switch(gadgetEquipped){
            case Gadget.STUN_GUN : stunGun.UnEquip(); break;
            case Gadget.NIGHT_VISION_GOOGLES : nightVisionGoggles.UnEquip(); break;
        }
        gadgetEquipped = Gadget.Empty;
    }

}
