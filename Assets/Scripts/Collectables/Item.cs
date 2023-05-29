
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemData data;
        private int stackSize;

        public ItemData Data {get => data; }
        public int StackSize {get => stackSize;}

        public void Initialize() {
            int stackSize = GetRandomStackSize();
            AddToStack(stackSize);
        }

        private int GetRandomStackSize(){
            return Random.Range(data.QuantityRange.min, data.QuantityRange.max+1);
        }

        public void AddToStack(int quantity){
            stackSize += quantity;
        }

        public void RemoveFromStack(int quantity){
            stackSize -= quantity;
        }
       
    }
}
