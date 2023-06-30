using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Items;

namespace ProfessionalThief.CCTV_NS
{
    public class CCTVStateMachine : MonoBehaviour, IStunnable
    {
        [SerializeField] private float stunnedDuration;
        private CCTVRotation cCTVRotation;
        private ScanState scanState;
        private StunnedState stunnedState;
        private CCTVState currentCCTVState;
        private bool isStunned;

        public float StunnedDuration => stunnedDuration;
        public CCTVRotation CCTVRotation => cCTVRotation;
        public ScanState ScanState => scanState;
        public StunnedState StunnedState => stunnedState;
        public bool IsStunned {get => isStunned; set => isStunned = value;}

        private void Awake() {
            cCTVRotation = GetComponent<CCTVRotation>();
            InitializeStates();
        }

        private void Start(){
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

        public void TakeStunDamage(){
            isStunned = true;
        }
    }
}
