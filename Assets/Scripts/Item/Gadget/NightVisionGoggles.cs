using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.Items
{
    public class NightVisionGoggles : Gadget
    {
        [SerializeField] private Light2D light2D;

        private void Start() {
            light2D.enabled = false;
        }
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge(){
            if(IsActive)
                ReduceCharge(Time.deltaTime);
            else if(currentCharge <= maxCharge)
                RestoreCharge(Time.deltaTime);
        }

        public override void UnEquip(){
            Deactivate();
        }

        protected override void Activate(){
            isActive = true;
            light2D.enabled = true;
        }

        protected override void Deactivate(){
            isActive = false;
            light2D.enabled = false;
        }
    }
}
