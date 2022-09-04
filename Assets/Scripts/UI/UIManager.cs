using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    [SerializeField] HudUI hudUI;

    public static UIManager Instance(){
        return instance;
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateCollectableValue(int value){
        hudUI.UpdateCollectableValue(value);
    }

    public void UpdateItemInfo(string info){
        hudUI.UpdateItemInfo(info);
    }

    public void UpdateActionLog(string text){
        hudUI.UpdateActionLog(text);
    }

    public void UpdateEquippedGadget(Gadget gadget){
        hudUI.UpdateEquippedGadget(gadget);
    }

    public void UpdateAvailableBattery(int value){
        hudUI.UpdateAvailableBattery(value);
    }

    public void UpdateChargeStatus(float value){
        hudUI.UpdateChargeStatus(value);
    }

}
