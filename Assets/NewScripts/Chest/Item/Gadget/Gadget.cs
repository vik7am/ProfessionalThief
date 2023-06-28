using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Items
{
    public enum GadgetId{TORCH, STUN_GUN, NIGHT_VISION_GOOGLES}
    
    public abstract class  Gadget : Item
    {
        public bool IsActive;
        public new string name;
        public string icon;
        public float maxCharge;
        public float currentCharge;

        protected virtual void Start(){
            currentCharge = maxCharge;
        }

        protected void RestoreCharge(float charge){
            currentCharge += charge;
            currentCharge = Mathf.Clamp(currentCharge, 0 , maxCharge);
        }

        protected void ReduceCharge(float charge){
            currentCharge -= charge;
            if(currentCharge <= 0)
                Deactivate();
        }

        public void ToggleState(){
            if(IsActive)
                Deactivate();
            else 
                Activate();
        }

        public abstract void Equip();

        public abstract void UnEquip();

        protected abstract void Activate();

        protected abstract void Deactivate();
    }
        
}
