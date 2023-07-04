
using UnityEngine;

namespace ProfessionalThief.Items
{
    public enum ValuableId{
        CASH,
        SILVER_COIN,
        GOLD_COIN
    }

    public class Valuable : MonoBehaviour
    {
        private ValuableId valuableId;
        private new string name;
        private int value;

        public string Name => name;
        public int Value => value;
        public ValuableId ValuableId => valuableId;

        public void Initialize(ValuableData data){
            name = data.name;
            valuableId = data.valuableId;
            value = data.value;
        }
    }
}
