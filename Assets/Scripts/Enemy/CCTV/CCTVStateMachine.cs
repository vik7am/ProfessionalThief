using UnityEngine;

namespace ProfessionalThief.CCTV
{
    public class CCTVStateMachine : MonoBehaviour
    {
        [SerializeField] private float stunnedDuration;
        private ScanState scanState;
        private StunnedState stunnedState;
        private CCTVState currentCCTVState;
        private CCTV cCTV;
        
        public float StunnedDuration => stunnedDuration;
        public ScanState ScanState => scanState;
        public StunnedState StunnedState => stunnedState;
        public CCTV CCTV => cCTV;

        private void Awake() {
            cCTV = GetComponent<CCTV>();
        }

        private void Start(){
            InitializeStates();
            ChangeState(scanState);
        }

        private void Update(){
            currentCCTVState.Update();
        }

        private void InitializeStates(){
            scanState = new ScanState(this);
            stunnedState = new StunnedState(this);
        }

        public void ChangeState(CCTVState cCTVState){
            if(currentCCTVState != null)
                currentCCTVState.OnStateExit();
            currentCCTVState = cCTVState;
            if(currentCCTVState != null)
                currentCCTVState.OnStateEnter();
        }
    }
}
