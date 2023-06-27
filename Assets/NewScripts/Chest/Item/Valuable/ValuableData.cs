using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Item
{
    [CreateAssetMenu(fileName ="ValuableData", menuName = "SO/ValuableData", order = 1)]
    public class ValuableData : ScriptableObject
    {
        public new string name;
        public ValuableId valuableId;
        public int minStackSize;
        public int maxStackSize;
        public int value;
    }
}
