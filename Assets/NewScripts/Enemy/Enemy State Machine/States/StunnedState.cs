using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Enemy
{
    public class StunnedState : EnemyState
    {
        private Movement movement;
        
        public StunnedState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine){
            movement = enemyStateMachine.Movement;
        }

        public override void OnStateEnter(){
            movement.SetMovementActive(true);
        }

        public override void Update(){

        }
    }
}
