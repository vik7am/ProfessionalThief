using UnityEngine;

namespace ProfessionalThief.Guard
{
    public class GuardStateMachine : MonoBehaviour
    {
        [SerializeField] private float stunnedDuration;
        private PatrolState patrolState;
        private StunnedState stunnedState;
        private GuardState currentGuardState;
        private Guard guard;

        public float StunnedDuration => stunnedDuration;
        public PatrolState PatrolState => patrolState;
        public StunnedState StunnedState => stunnedState;
        public Guard Guard => guard;

        private void Awake() {
            guard = GetComponent<Guard>();
        }

        private void Start(){
            InitializeStates();
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
