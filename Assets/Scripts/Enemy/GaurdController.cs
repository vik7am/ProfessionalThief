using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdController : MonoBehaviour
{
    GaurdMovement gaurdMovement;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField] GameObject pointLight;

    void Awake()
    {
        gaurdMovement = GetComponent<GaurdMovement>();
    }

    public void DisableGaurd(){
        gaurdMovement.StopMovement();
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
    }
}
