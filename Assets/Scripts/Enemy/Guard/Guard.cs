using System;
using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Core;
using ProfessionalThief.Enemy;
using ProfessionalThief.Items;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.GuardNS
{
    public class AnimatorParameter{
        public static string GUARD_SPEED = "speed";
    }

    public class Guard : MonoBehaviour, IStunnable
    {
        private Movement movement;
        private Patroling patrolling;
        [SerializeField] private PlayerDetector playerDetector;
        [SerializeField] private Light2D bodyLight;
        [SerializeField] private Animator animator;

        public Movement Movement => movement;
        public Patroling Patroling => patrolling;
        public PlayerDetector PlayerDetector => playerDetector;
        public Light2D BodyLight => bodyLight;

        public event Action onHitByStunBullet;

        private void Awake() {
            movement = GetComponent<Movement>();
            patrolling = GetComponent<Patroling>();
        }

        private void Update() {
            UpdateAnimation();
        }

        private void UpdateAnimation(){
            animator.SetFloat(AnimatorParameter.GUARD_SPEED, movement.CurrentSpeed);
        }

        public void TakeStunDamage(){
            onHitByStunBullet?.Invoke();
        }
    }
}
