using UnityEngine;

namespace ProfessionalThief.Guard
{
    public class StunnedState : GuardState
    {
        private Guard guard;
        private float stunnedDurationLeft;

        public StunnedState(GuardStateMachine guardStateMachine) : base(guardStateMachine){
            guard = guardStateMachine.Guard;
        }

        public override void OnStateEnter(){
            guard.onHitByStunBullet += HandleOnHitByStunBullet;
            stunnedDurationLeft = guardStateMachine.StunnedDuration;
            guard.PlayerDetector.SetDetectionActive(false);
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
            guard.PlayerDetector.SetDetectionActive(true);
            guard.BodyLight.enabled = true;
        }

        private void HandleOnHitByStunBullet(){
            guardStateMachine.ChangeState(guardStateMachine.StunnedState);
        }
    }
}
