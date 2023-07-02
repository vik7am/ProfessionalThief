using System;
using UnityEngine;
namespace ProfessionalThief.CCTV_NS
{
    public class ScanState : CCTVState
    {
        private CCTV cCTV;
        private CCTVRotation cCTVRotation;

        public ScanState(CCTVStateMachine cCTVStateMachine) : base(cCTVStateMachine){
            cCTV = cCTVStateMachine.CCTV;
            cCTVRotation = cCTV.CCTVRotation;
        }

        public override void OnStateEnter(){
            cCTV.onHitByStunBullet += HandleOnHitByStunBullet;
            cCTV.PlayerDetector.SetDetectionActive(true);
            cCTVRotation.SetRotationActive(true);
        }

        public override void Update(){}

        public override void OnStateExit(){
            cCTV.onHitByStunBullet -= HandleOnHitByStunBullet;
            cCTVRotation.SetRotationActive(false);
        }

        private void HandleOnHitByStunBullet(){
            cCTVStateMachine.ChangeState(cCTVStateMachine.StunnedState);
        }
    }
}
