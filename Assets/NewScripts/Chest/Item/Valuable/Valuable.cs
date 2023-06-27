using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Item
{
    public enum ValuableId{CASH, SILVER_COIN, GOLD_COIN}

    public class Valuable
    {
        public ValuableId id;
        public string name;
        public int value;

        public Valuable(ValuableData data){
            id = data.valuableId;
            name = data.name;
            value = data.value;
        }
    }
}
