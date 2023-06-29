using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Enemy;

namespace ProfessionalThief.GuardNS
{
    public class GuardStateMachine : MonoBehaviour
    {
        private Movement movement;
        private PatrolState patrolState;
        private StunnedState stunnedState;
        private GuardState currentGuardState;
        private Patroling patrolling;

        public Movement Movement => movement;
        public PatrolState PatrolState => patrolState;
        public StunnedState StunnedState => stunnedState;
        public GuardState CurrentGuardState => currentGuardState;
        public Patroling Patroling => patrolling;

        private void Awake() {
            movement = GetComponent<Movement>();
            patrolling = GetComponent<Patroling>();
            InitializeStates();
        }

        private void Start(){
            ChangeState(patrolState);
        }

        private void Update(){
            currentGuardState.Update();
        }

        private void InitializeStates(){
            patrolState = new PatrolState(this);
            stunnedState = new StunnedState(this);
            stunnedState = new StunnedState(this);
        }

        public void ChangeState(GuardState guardState){
            if(currentGuardState != null)
                currentGuardState.OnStateExit();
            currentGuardState = guardState;
            if(currentGuardState != null)
                currentGuardState.OnStateEnter();
        }
    }
}
