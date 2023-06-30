using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Enemy;
namespace ProfessionalThief.GuardNS
{
    public class PatrolState : GuardState
    {
        private Guard guard;
        private Patroling patrolling;

        public PatrolState(GuardStateMachine guardStateMachine) : base(guardStateMachine){
            guard = guardStateMachine.Guard;
            patrolling = guard.Patroling;
        }

        public override void OnStateEnter(){
            guard.onHitByStunBullet += HandleOnHitByStunBullet;
            patrolling.SetPatrollingActive(true);
        }

        public override void Update(){}

        public override void OnStateExit(){
            guard.onHitByStunBullet -= HandleOnHitByStunBullet;
            patrolling.SetPatrollingActive(false);
        }

        private void HandleOnHitByStunBullet(){
            guardStateMachine.ChangeState(guardStateMachine.StunnedState);
        }
    }
}
