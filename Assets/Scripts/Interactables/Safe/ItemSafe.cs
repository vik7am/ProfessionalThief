using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class ItemSafe : Safe
    {
        [SerializeField] private List<ItemData> itemDataList;

        public override void InitializeCollectable()
        {
            ItemData itemData = itemDataList[Random.Range(0, itemDataList.Count)];
            collectable =  new Item(itemData);
        }
    }
}
