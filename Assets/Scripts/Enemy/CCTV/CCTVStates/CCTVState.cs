
namespace ProfessionalThief.CCTV
{
    public abstract class CCTVState
    {
        protected CCTVStateMachine cCTVStateMachine;

        public CCTVState(CCTVStateMachine cCTVStateMachine){
            this.cCTVStateMachine = cCTVStateMachine;
        }

        public abstract void Update();
        public virtual void OnStateEnter(){}
        public virtual void OnStateExit(){}
    }
}
