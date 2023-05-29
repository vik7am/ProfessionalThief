
using UnityEngine;

namespace ProfessionalThief{

    public abstract class Gadget : MonoBehaviour
    {
        [SerializeField] protected PlayerInventory inventory;
        [SerializeField] protected int charge;
        protected float currentCharge;
        protected bool equipped;
        protected bool active;
        public abstract void Equip();
        public abstract void UnEquip();
        public abstract void Use();
        public abstract void Recharge();
    }
}
