using UnityEngine;

namespace ProfessionalThief.V1{
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
        gadgetController.UnEquipAllGadget();
        animator.enabled = false;
        torchLight.SetActive(false);
    }
}
}
