using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Enemy
{
    public class IdleState : EnemyState
    {
        private Movement movement;
        private int idleDuration;
        private float timePassed;

        public IdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine) {
            movement = enemyStateMachine.Movement;
            idleDuration = enemyStateMachine.IdleDuration;
        }

        public override void OnStateEnter(){
            movement.DisableMovement(true);
            timePassed = 0;
        }

        public override void Update(){
            if(timePassed < idleDuration){
                timePassed += Time.deltaTime;
                return;
            }
            enemyStateMachine.ChangeState(enemyStateMachine.NormalState);
        }
    }
}
