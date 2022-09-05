using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;
    [SerializeField] GadgetController gadgetController;
    [SerializeField] GameObject torchLight;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    public void DisablePlayer()
    {
        playerMovement.StopMovement();
        animator.enabled = false;
        torchLight.SetActive(false);
    }
}
