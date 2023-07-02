using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Items
{
    public class Valuable : Item
    {
        private new string name;
        private int value;
        private int stackSize;

        public string Name => name;
        public int Value => value;
        public int StackSize => stackSize;

        public void Initialize(ValuableData data, int stackSize){
            name = data.name;
            itemId = data.itemId;
            value = data.value;
            this.stackSize = stackSize;
        }

        public void AddToStack(Valuable valuable){
            stackSize += valuable.stackSize;
        }
    }
}
