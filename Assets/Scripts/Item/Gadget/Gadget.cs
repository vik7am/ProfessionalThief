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
        [SerializeField] private GadgetId gadgetId;
        [SerializeField] protected new string name;
        [SerializeField] protected string icon;
        [SerializeField][Range(0,1)]
        protected float chargeReductionRate;
        [SerializeField][Range(0,1)]
        protected float chargeRestorationRate;
        protected bool isActive;
        protected float maxCharge;
        protected float currentCharge;

        public GadgetId GadgetId => gadgetId;
        public string Name => name;
        public string Icon => icon;
        public bool IsActive => isActive;
        public float MaxCharge => maxCharge;
        public float Currentcharge => currentCharge;

        private void Awake(){
            currentCharge = maxCharge = 1;
        }

        protected void RestoreCharge(float charge){
            currentCharge += charge;
            currentCharge = Mathf.Clamp01(currentCharge);
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

        protected virtual void Activate() {}
        protected virtual void Deactivate() {}

        public virtual void Equip() {}
        public virtual void UnEquip() {}
    }
        
}
