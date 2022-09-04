using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdController : MonoBehaviour
{
    GaurdMovement gaurdMovement;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField] GameObject pointLight;
    bool active;

    void Awake()
    {
        active = true;
        gaurdMovement = GetComponent<GaurdMovement>();
    }

    public bool IsActive(){
        return active;
    }

    public void DisableGaurd(){
        active = false;
        gaurdMovement.StopMovement();
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
    }
}
