using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GadgetController gadgetController;
    [SerializeField] GameObject torchLight;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void DisablePlayer()
    {
        playerMovement.StopMovement();
        torchLight.SetActive(false);
    }
}
