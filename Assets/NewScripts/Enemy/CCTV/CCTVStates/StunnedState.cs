using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.CCTV_NS
{
    public class StunnedState : CCTVState
    {
        private float stunnedDurationLeft;

        public StunnedState(CCTVStateMachine cCTVStateMachine) : base(cCTVStateMachine){
        }

        public override void OnStateEnter(){
            stunnedDurationLeft = cCTVStateMachine.StunnedDuration;
        }

        public override void OnStateExit(){
            cCTVStateMachine.IsStunned = false;
        }

        public override void Update(){
            stunnedDurationLeft -= Time.deltaTime;
            if(stunnedDurationLeft <= 0){
                cCTVStateMachine.ChangeState(cCTVStateMachine.ScanState);
            }
        }
    }
}
