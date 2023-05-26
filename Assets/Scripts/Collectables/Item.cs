using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class Item
    {
        public ItemID itemID;
        public ItemData itemData;
        public int stackSize;

        public Item(ItemData itemData){
            this.itemData = itemData;
        }
    }
}
