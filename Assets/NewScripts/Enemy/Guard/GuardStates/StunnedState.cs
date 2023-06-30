using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Enemy;
using UnityEngine;

namespace ProfessionalThief.GuardNS
{
    public class StunnedState : GuardState
    {
        private Guard guard;
        private float stunnedDurationLeft;
        private PlayerDetector playerDetector;

        public StunnedState(GuardStateMachine guardStateMachine) : base(guardStateMachine){
            guard = guardStateMachine.Guard;
            playerDetector = guard.PlayerDetector;
        }

        public override void OnStateEnter(){
            guard.onHitByStunBullet += HandleOnHitByStunBullet;
            stunnedDurationLeft = guardStateMachine.StunnedDuration;
            playerDetector.SetDetectionActive(false);
            guard.BodyLight.enabled = false;
        }

        public override void Update(){
            stunnedDurationLeft -= Time.deltaTime;
            if(stunnedDurationLeft <= 0){
                guardStateMachine.ChangeState(guardStateMachine.PatrolState);
            }
        }

        public override void OnStateExit(){
            guard.onHitByStunBullet -= HandleOnHitByStunBullet;
            playerDetector.SetDetectionActive(true);
            guard.BodyLight.enabled = true;
        }

        private void HandleOnHitByStunBullet(){
            guardStateMachine.ChangeState(guardStateMachine.StunnedState);
        }
    }
}
