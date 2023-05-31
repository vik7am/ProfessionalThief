
using UnityEngine;
using System;

namespace ProfessionalThief{

    public abstract class Gadget : MonoBehaviour, ICollectable
    {
        protected PlayerInventory inventory;
        [SerializeField] protected int charge;
        protected float currentCharge;
        protected bool equipped;
        protected bool active;
        protected GadgetID id;
        [SerializeField] protected string icon;
        public abstract void Equip();
        public abstract void UnEquip();
        public abstract void Use();
        public abstract void Recharge();

        //public static event Action<bool> OnGadgetActive;
        //public static event Action OnGadgedRecharged;
        
        public GadgetID ID { get => id; }
        public string Icon { get => icon; }
        public int Charge {get => charge; }
        public float CurrentCharge { get => currentCharge; }

        public CollectableID GetCollectableID()
        {
            return CollectableID.GADGET;
        }
    }
}
