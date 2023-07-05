using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using ProfessionalThief.Core;

namespace ProfessionalThief.Guard
{
    public class Guard : MonoBehaviour, IStunnable
    {
        private Movement movement;
        private Patroling patrolling;
        private BoxCollider2D boxCollider2D;
        [SerializeField] private PlayerDetector playerDetector;
        [SerializeField] private Light2D bodyLight;
        [SerializeField] private Animator animator;

        public Movement Movement => movement;
        public Patroling Patroling => patrolling;
        public PlayerDetector PlayerDetector => playerDetector;
        public Light2D BodyLight => bodyLight;
        public BoxCollider2D BoxCollider2D => boxCollider2D;

        public event Action onHitByStunBullet;

        private void Awake() {
            movement = GetComponent<Movement>();
            patrolling = GetComponent<Patroling>();
            boxCollider2D = GetComponent<BoxCollider2D>();
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
