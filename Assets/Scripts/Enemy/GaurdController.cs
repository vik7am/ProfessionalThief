using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaurdController : MonoBehaviour
{
    GaurdMovement gaurdMovement;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField] GameObject pointLight;
    [SerializeField] float recoveryTime;
    [SerializeField] float activationTime;
    bool active;

    void Awake()
    {
        active = true;
        gaurdMovement = GetComponent<GaurdMovement>();
    }

    void Update() {
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
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
        if(GameManager.Instance().IsGameOver())
            return;
        StartCoroutine(RecoverGaurd());
    }

    public void EnableGaurd(){
        active = true;
        gaurdMovement.StartMovement();
        intruderDetection.gameObject.SetActive(true);
    }

    IEnumerator RecoverGaurd(){
        yield return new WaitForSeconds(recoveryTime);
        pointLight.SetActive(true);
        yield return new WaitForSeconds(activationTime);
        EnableGaurd();
    }
}
