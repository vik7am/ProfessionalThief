using UnityEngine;

namespace ProfessionalThief.Items
{
    [CreateAssetMenu(fileName ="ValuableData", menuName = "SO/ValuableData", order = 1)]
    public class ValuableData : ScriptableObject
    {
        public new string name;
        public ItemId itemId;
        public int minStackSize;
        public int maxStackSize;
        public int value;
    }
}
