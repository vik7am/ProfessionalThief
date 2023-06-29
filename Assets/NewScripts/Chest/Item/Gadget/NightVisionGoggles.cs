using System.Collections;
using System.Collections.Generic;
using ProfessionalThief.Items;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief
{
    public class NightVisionGoggles : Gadget
    {
        [SerializeField] private Light2D light2D;

        protected override void Start() {
            base.Start();
            light2D.enabled = false;
        }
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge(){
            if(IsActive){
                ReduceCharge(Time.deltaTime);
            }
            else if(currentCharge <= maxCharge){
                RestoreCharge(Time.deltaTime);
            }
        }

        public override void Equip(){
        }

        public override void UnEquip(){
            Deactivate();
        }

        protected override void Activate(){
            IsActive = true;
            light2D.enabled = true;
        }

        protected override void Deactivate(){
            IsActive = false;
            light2D.enabled = false;
        }
    }
}
