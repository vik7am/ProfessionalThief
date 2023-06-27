using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Item
{
    public enum GadgetId{TORCH, STUN_GUN, NIGHT_VISION_GOOGLES}
    
    public abstract class  Gadget : MonoBehaviour
    {
        public GadgetId id;
    }
        
}
