using UnityEngine;

namespace ProfessionalThief.V1{
public class PrimaryTarget : MonoBehaviour
{
    [SerializeField] GateController gate;
    [SerializeField] GadgetType gadgetType;
    bool safeEmpty;
    bool interactable;

    void Update()
    {
        if(safeEmpty || !interactable)
            return;
        if(Input.GetKeyDown(KeyCode.E)){
            GameManager.Instance().UnlockGadget(gadgetType);
            gate.OpenGate();
            ShowGadgetControlls();
            safeEmpty = true;
        }
    }

    void ShowGadgetControlls(){
        string infoText = "";
        string gadgetName = "";
        switch(gadgetType){
            case GadgetType.TORCH : 
                infoText = "Press 1 to Equip and Unequip"; 
                gadgetName = "Torch"; break;
            case GadgetType.STUN_GUN : 
                infoText = "Press 2 to Equip and Unequip"; 
                gadgetName = "Stun Gun"; break;
            case GadgetType.NIGHT_VISION_GOOGLES : 
                infoText = "Press 3 to Equip and Unequip"; 
                gadgetName = "Night Vision Googles"; break;
        }
        UIManager.Instance().UpdateItemInfo(infoText);
        if(!safeEmpty)
            UIManager.Instance().UpdateActionLog("Collected " + gadgetName);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        interactable = true;
        if(safeEmpty)
            ShowGadgetControlls();
        else
            UIManager.Instance().UpdateItemInfo("Press E to collect");

    }

    private void OnCollisionExit2D(Collision2D other) {
        interactable = false;
        if(safeEmpty){
            UIManager.Instance().UpdateActionLog("Press Space to Activate and Deactivate");
        }
        UIManager.Instance().UpdateItemInfo("");
    }
}
}