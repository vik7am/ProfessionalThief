using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.Items
{
    public class Torch : Gadget
    {
        [SerializeField] private Light2D light2D;

        private void Start() {
            light2D.enabled = false;
        }
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge(){
            if(IsActive){
                ReduceCharge(chargeReductionRate * Time.deltaTime);
            }
            else if(currentCharge <= maxCharge){
                RestoreCharge(chargeRestorationRate * Time.deltaTime);
            }
        }

        protected override void Activate(){
            isActive = true;
            light2D.enabled = true;
        }

        protected override void Deactivate(){
            isActive = false;
            light2D.enabled = false;
        }
        
        public override void UnEquip(){
            Deactivate();
        }
    }
}
