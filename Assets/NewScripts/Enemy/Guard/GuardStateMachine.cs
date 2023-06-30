using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;
using ProfessionalThief.Enemy;
using ProfessionalThief.Items;

namespace ProfessionalThief.GuardNS
{
    public class GuardStateMachine : MonoBehaviour, IStunnable
    {
        [SerializeField] private float stunnedDuration;
        private Movement movement;
        private PatrolState patrolState;
        private StunnedState stunnedState;
        private GuardState currentGuardState;
        private Patroling patrolling;
        private bool isStunned;

        public float StunnedDuration => stunnedDuration;
        public Movement Movement => movement;
        public PatrolState PatrolState => patrolState;
        public StunnedState StunnedState => stunnedState;
        public Patroling Patroling => patrolling;
        public bool IsStunned {get => isStunned; set => isStunned = value;}

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

        public void TakeStunDamage(){
            isStunned = true;
        }
    }
}
