using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public enum ItemID {CASH, SILVER_COIN, GOLD_COIN, BATTERY, TORCH,  STUN_GUN, NIGHT_VISION_GOGGLES}
    public enum ItemType {VALUABLE, GADGET};

    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private ItemID id;
        [SerializeField] private ItemType type;
        [SerializeField] private new string name;
        [SerializeField] private int value;
        [SerializeField] private Range quantityRange;

        public ItemID ID { get => id; }
        public ItemType Type {get => type; }
        public string Name {get => name; }
        public int Value { get => value; }
        public Range QuantityRange { get => quantityRange; }
    }
    
    [System.Serializable]
    public struct Range{
        public int min, max;
    }
}
