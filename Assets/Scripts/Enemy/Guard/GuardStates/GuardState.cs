
namespace ProfessionalThief.Guard
{
    public abstract class GuardState
    {
        protected GuardStateMachine guardStateMachine;

        public GuardState(GuardStateMachine guardStateMachine){
            this.guardStateMachine = guardStateMachine;
        }

        public abstract void Update();
        public virtual void OnStateEnter(){}
        public virtual void OnStateExit(){}
    }
}
