
using UnityEngine;

namespace ProfessionalThief{

    public abstract class Gadget : MonoBehaviour, ICollectable
    {
        protected PlayerInventory inventory;
        [SerializeField] protected int charge;
        protected float currentCharge;
        protected bool equipped;
        protected bool active;
        protected GadgetID gadgetID;
        public abstract void Equip();
        public abstract void UnEquip();
        public abstract void Use();
        public abstract void Recharge();
        
        public GadgetID GetID(){
            return gadgetID;
        }

        public CollectableID GetCollectableID()
        {
            return CollectableID.GADGET;
        }
    }
}
