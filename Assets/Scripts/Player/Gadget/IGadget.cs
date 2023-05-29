
using UnityEngine;

namespace ProfessionalThief{

    public abstract class IGadget : MonoBehaviour
    {
        public abstract void EquipGadget();
        public abstract void UnEquipGadget();
        public abstract void UseGadget();
        public abstract void RechargeGadget();
    }
}
