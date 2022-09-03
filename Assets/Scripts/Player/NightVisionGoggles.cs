using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVisionGoggles : MonoBehaviour
{
    [SerializeField] GameObject greenLight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.N)){
            greenLight.SetActive(!greenLight.activeSelf);
        }
    }
}
