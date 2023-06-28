using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.Items
{
    public class Torch : Gadget
    {
        private bool isEquiped;
        private Light2D light2D;

        private void Start() {
        }
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge()
        {
            if(IsActive){
                currentCharge -= Time.deltaTime;
            }
            else if(!isEquiped && currentCharge <= maxCharge){
                currentCharge += Time.deltaTime;
                currentCharge = Mathf.Clamp(currentCharge, 0 , maxCharge);
            }
        }

        public override void Equip(){
            isEquiped = true;
        }

        public override void UnEquip(){
            isEquiped = false;
        }

        public override void Activate(){
            IsActive = true;
            light2D.enabled = true;
        }

        public override void Deactivate(){
            IsActive = false;
            light2D.enabled = false;
        }
    }
}
