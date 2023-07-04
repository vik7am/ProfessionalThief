using UnityEngine;

namespace ProfessionalThief.Items
{
    public enum GadgetId{
        TORCH = ItemId.GADGET_TORCH,
        STUN_GUN = ItemId.GADGET_STUN_GUN,
        NIGHT_VISION_GOGGLES = ItemId.GADGET_NIGHT_VISION_GOGGLES
    }

    public class  Gadget : MonoBehaviour
    {
        protected bool isActive;
        [SerializeField] private GadgetId gadgetId;
        [SerializeField] protected new string name;
        [SerializeField] protected string icon;
        [SerializeField] protected float maxCharge;
        protected float currentCharge;

        public bool IsActive => isActive;
        public GadgetId GadgetId => gadgetId;
        public string Name => name;
        public string Icon => icon;
        public float MaxCharge => maxCharge;
        public float Currentcharge => currentCharge;

        private void Awake(){
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

        public virtual void Equip() {}

        public virtual void UnEquip() {}

        protected virtual void Activate() {}

        protected virtual void Deactivate() {}
    }
        
}
