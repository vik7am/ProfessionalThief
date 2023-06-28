using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Items
{
    public enum ValuableId{CASH, SILVER_COIN, GOLD_COIN}

    public class Valuable : Item
    {
        public ValuableId id;
        public new string name;
        public int value;
        public int stackSize;

        public void Initialize(ValuableData data, int stackSize){
            id = data.valuableId;
            name = data.name;
            value = data.value;
            this.stackSize = stackSize;
        }
    }
}
