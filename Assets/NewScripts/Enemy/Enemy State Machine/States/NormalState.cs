using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Enemy
{
    public class NormalState : EnemyState
    {
        private Movement movement;

        public NormalState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine){
            movement = enemyStateMachine.Movement;
        }

        public override void OnStateEnter(){
            movement.SetMovementActive(false);
        }

        public override void Update(){
            
        }
    }
}
