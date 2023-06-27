using System.Collections;
using UnityEngine;

namespace ProfessionalThief.V1{
public class CCTVController : MonoBehaviour
{
    Animator animator;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField] GameObject pointLight;
    [SerializeField] float recoveryTime;
    [SerializeField] float activationTime;
    bool active;

    void Awake()
    {
        active = true;
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(GameManager.Instance() == null)
            return;
        if(GameManager.Instance().IsGameOver())
            if(IsActive())
                DisableCCTV();
    }

    public bool IsActive(){
        return active;
    }

    public void DisableCCTV(){
        active = false;
        animator.enabled = false;
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
        if(GameManager.Instance().IsGameOver())
            return;
        StartCoroutine(RecoverCCTV());
    }

    public void EnableCCTV(){
        active = true;
        animator.enabled = true;
        intruderDetection.gameObject.SetActive(true);
    }

    IEnumerator RecoverCCTV(){
        yield return new WaitForSeconds(recoveryTime);
        pointLight.SetActive(true);
        yield return new WaitForSeconds(activationTime);
        EnableCCTV();
    }
}
}
