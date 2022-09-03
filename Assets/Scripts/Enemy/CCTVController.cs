using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVController : MonoBehaviour
{
    Animator animator;
    [SerializeField] IntruderDetection intruderDetection;
    [SerializeField]GameObject pointLight;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void DisableCCTV(){
        animator.enabled = false;
        intruderDetection.gameObject.SetActive(false);
        pointLight.SetActive(false);
    }
}
