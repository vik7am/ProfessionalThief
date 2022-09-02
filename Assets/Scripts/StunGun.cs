using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : MonoBehaviour
{
    [SerializeField] Bullet bullet;

    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput(){
        if(Input.GetKeyDown(KeyCode.Space))
            FireGun();
    }

    void FireGun(){
        Instantiate(bullet, transform.position, transform.parent.localRotation);
    }

}
