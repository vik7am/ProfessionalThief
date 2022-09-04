using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVController : MonoBehaviour
{
    Animator animator;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField]GameObject pointLight;
    bool active;

    void Awake()
    {
        active = true;
        animator = GetComponent<Animator>();
    }

    public bool IsActive(){
        return active;
    }

    public void DisableCCTV(){
        active = false;
        animator.enabled = false;
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
    }
}
