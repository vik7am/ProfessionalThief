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

        public abstract void Equip();

        public abstract void UnEquip();

        public abstract void Activate();

        public abstract void Deactivate();
    }
        
}
