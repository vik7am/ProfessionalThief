using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public interface IUnlockable{
        bool IsLocked();
        void Unlock();
    }

    public class Safe : MonoBehaviour, IUnlockable
    {
        private bool isLocked;
        [SerializeField] private List<ItemData> itemDataList;
        private Item item;

        private void Start()
        {
            isLocked = true;
        }

        public bool IsLocked()
        {
            return isLocked;
        }

        public void Unlock()
        {
            ItemData itemData = itemDataList[Random.Range(0, itemDataList.Count)];
            int itemQuantity = Random.Range(itemData.QuantityRange.min, itemData.QuantityRange.max+1);
            item = new Item(itemData);
            item.stackSize = itemQuantity;
            isLocked = false;
        }

        public Item GetItem(){
            return item;
        }
    }
}
