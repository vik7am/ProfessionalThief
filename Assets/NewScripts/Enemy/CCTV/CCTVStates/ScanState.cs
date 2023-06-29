using UnityEngine;
namespace ProfessionalThief.CCTV_NS
{
    public class ScanState : CCTVState
    {
        private CCTVRotation cCTVRotation;

        public ScanState(CCTVStateMachine cCTVStateMachine) : base(cCTVStateMachine){
            cCTVRotation = cCTVStateMachine.CCTVRotation;
        }

        public override void OnStateEnter(){
            cCTVRotation.SetRotationActive(true);
        }

        public override void OnStateExit(){
            cCTVRotation.SetRotationActive(false);
        }

        public override void Update(){
            if(cCTVStateMachine.IsStunned){
                cCTVStateMachine.ChangeState(cCTVStateMachine.StunnedState);
            }
        }
    }
}
