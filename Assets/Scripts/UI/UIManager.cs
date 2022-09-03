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

}
