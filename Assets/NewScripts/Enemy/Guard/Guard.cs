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
    public class Guard : MonoBehaviour, IStunnable
    {
        private Movement movement;
        private Patroling patrolling;
        [SerializeField] private PlayerDetector playerDetector;
        [SerializeField] private Light2D bodyLight;

        public Movement Movement => movement;
        public Patroling Patroling => patrolling;
        public PlayerDetector PlayerDetector => playerDetector;
        public Light2D BodyLight => bodyLight;

        public event Action onHitByStunBullet;

        private void Awake() {
            movement = GetComponent<Movement>();
            patrolling = GetComponent<Patroling>();
        }

        public void TakeStunDamage(){
            onHitByStunBullet?.Invoke();
        }
    }
}
