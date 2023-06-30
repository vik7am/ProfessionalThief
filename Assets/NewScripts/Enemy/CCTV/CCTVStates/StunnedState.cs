using System;
using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Enemy;
using UnityEngine;

namespace ProfessionalThief.CCTV_NS
{
    public class StunnedState : CCTVState
    {
        private float stunnedDurationLeft;
        private CCTV cCTV;
        private PlayerDetector playerDetector;

        public StunnedState(CCTVStateMachine cCTVStateMachine) : base(cCTVStateMachine){
            cCTV = cCTVStateMachine.CCTV;
            playerDetector = cCTV.PlayerDetector;
        }

        public override void OnStateEnter(){
            cCTV.onHitByStunBullet += HandleOnHitByStunBullet;
            stunnedDurationLeft = cCTVStateMachine.StunnedDuration;
            playerDetector.SetDetectionActive(false);
            cCTV.BodyLight.enabled = false;
        }

        public override void Update(){
            stunnedDurationLeft -= Time.deltaTime;
            if(stunnedDurationLeft <= 0){
                cCTVStateMachine.ChangeState(cCTVStateMachine.ScanState);
            }
        }

        public override void OnStateExit(){
            cCTV.onHitByStunBullet -= HandleOnHitByStunBullet;
            playerDetector.SetDetectionActive(true);
            cCTV.BodyLight.enabled = true;
        }

        private void HandleOnHitByStunBullet(){
            cCTVStateMachine.ChangeState(cCTVStateMachine.StunnedState);
        }
    }
}
