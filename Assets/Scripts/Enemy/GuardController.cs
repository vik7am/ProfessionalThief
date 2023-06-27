using System.Collections;
using UnityEngine;

namespace ProfessionalThief.V1{
public class GuardController : MonoBehaviour{
    GuardMovement gaurdMovement;
    Animator animator;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField] GameObject pointLight;
    [SerializeField] float recoveryTime;
    [SerializeField] float activationTime;
    bool active;

    void Awake()
    {
        active = true;
        gaurdMovement = GetComponent<GuardMovement>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(GameManager.Instance() == null)
            return;
        if(GameManager.Instance().IsGameOver())
            if(IsActive())
                DisableGaurd();
    }

    public bool IsActive(){
        return active;
    }

    public void DisableGaurd(){
        active = false;
        gaurdMovement.StopMovement();
        animator.enabled = false;
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
        if(GameManager.Instance().IsGameOver())
            return;
        StartCoroutine(RecoverGaurd());
    }

    public void EnableGaurd(){
        active = true;
        gaurdMovement.StartMovement();
        animator.enabled = true;
        intruderDetection.gameObject.SetActive(true);
    }

    IEnumerator RecoverGaurd(){
        yield return new WaitForSeconds(recoveryTime);
        pointLight.SetActive(true);
        yield return new WaitForSeconds(activationTime);
        EnableGaurd();
    }
}}
