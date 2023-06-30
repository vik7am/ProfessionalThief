using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.GuardNS
{
    public class StunnedState : GuardState
    {
        private float stunnedDurationLeft;

        public StunnedState(GuardStateMachine guardStateMachine) : base(guardStateMachine){
        }

        public override void OnStateEnter(){
            stunnedDurationLeft = guardStateMachine.StunnedDuration;
        }

        public override void OnStateExit(){
            guardStateMachine.IsStunned = false;
        }

        public override void Update(){
            stunnedDurationLeft -= Time.deltaTime;
            if(stunnedDurationLeft <= 0){
                guardStateMachine.ChangeState(guardStateMachine.PatrolState);
            }
        }
    }
}
