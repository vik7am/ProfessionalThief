using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Enemy
{
    public abstract class EnemyState
    {
        protected EnemyStateMachine enemyStateMachine;

        public EnemyState(EnemyStateMachine enemyStateMachine){
            this.enemyStateMachine = enemyStateMachine;
        }

        public abstract void Update();
        public virtual void OnStateEnter(){}
        public virtual void OnStateExit(){}
    }
}
