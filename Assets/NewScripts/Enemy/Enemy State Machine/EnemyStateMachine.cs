using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Enemy;

namespace ProfessionalThief.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
        private Movement movement;
        [SerializeField] private int idleDuration;

        public Movement Movement {get => movement;}
        public int IdleDuration {get=> idleDuration;}

        private NormalState normalState;
        private IdleState idleState;
        private StunnedState stunnedState;
        private EnemyState currentEnemyState;

        public NormalState NormalState {get => normalState;}
        public IdleState IdleState {get => idleState;}
        public StunnedState StunnedState {get => stunnedState;}

        private void Awake() {
            movement = GetComponent<Movement>();
        }

        private void Start(){
            InitializeStates();
            ChangeState(normalState);
        }

        private void Update(){
            currentEnemyState.Update();
        }

        public void InitializeStates(){
            normalState = new NormalState(this);
            idleState = new IdleState(this);
            stunnedState = new StunnedState(this);
        }

        public void ChangeState(EnemyState enemyState){
            if(currentEnemyState != null)
                currentEnemyState.OnStateExit();
            currentEnemyState = enemyState;
            if(currentEnemyState != null)
                currentEnemyState.OnStateEnter();
        }
    }
}
