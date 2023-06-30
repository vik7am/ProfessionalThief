using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Enemy;
namespace ProfessionalThief.GuardNS
{
    public class PatrolState : GuardState
    {
        private Patroling patrolling;

        public PatrolState(GuardStateMachine guardStateMachine) : base(guardStateMachine){
            patrolling = guardStateMachine.Patroling;
        }

        public override void OnStateEnter(){
            patrolling.SetPatrollingActive(true);
        }

        public override void OnStateExit(){
            patrolling.SetPatrollingActive(false);
        }

        public override void Update(){
            if(guardStateMachine.IsStunned){
                guardStateMachine.ChangeState(guardStateMachine.StunnedState);
            }
        }
    }
}
