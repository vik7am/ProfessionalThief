using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class Player : MonoBehaviour
    {
        PlayerMovement playerMovement;
        Animator animator;
        PlayerInput playerInput;
        Camera cam;

        void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            animator = GetComponent<Animator>();
            playerInput = GetComponent<PlayerInput>();
            cam = Camera.main;
        }

        void LateUpdate()
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y , -10);
        }

        void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if(playerInput.MovementInput == Vector2.zero)
                animator.SetBool("walking", false);
            else
                animator.SetBool("walking", true);
        }
    }
}
