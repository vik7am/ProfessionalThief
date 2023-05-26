using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public enum ItemID{CASH, SILVER_COIN, GOLD_COIN, BATTERY}

    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private ItemID itemID;
        [SerializeField] private string itemName;
        [SerializeField] private int itemValue;
        [SerializeField] private Range itemQuantityRange;

        public ItemID ID { get => itemID; }
        public string Name {get => itemName; }
        public int Value { get => itemValue; }
        public Range QuantityRange { get => itemQuantityRange; }
    }
    
    [System.Serializable]
    public struct Range{
        public int min, max;
    }
}
