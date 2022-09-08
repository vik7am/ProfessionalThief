using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief{
public class PrimaryTarget : MonoBehaviour
{
    [SerializeField] GateController gate;
    [SerializeField] GadgetType gadgetType;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            GameManager.Instance().UnlockGadget(gadgetType);
            gate.OpenGate();
            UIManager.Instance().UpdateItemInfo("");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("Press E to collect");
    }

    private void OnCollisionExit2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("");
    }
}
}