using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] int ammo;

    void Update()
    {
        //GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Space))
            FireGun();
    }

    void FireGun(){
        Instantiate(bullet, transform.position, transform.parent.parent.localRotation);
    }

    public void Reload(){

    }

    public void Equip(){

    }

    public void UnEquip(){
        
    }

}
