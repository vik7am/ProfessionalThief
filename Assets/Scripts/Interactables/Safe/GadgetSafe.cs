using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class GadgetSafe : Safe
    {
        [SerializeField] private Gadget gadgetPrefab;

        public override void  InitializeCollectable() {
            collectable = Instantiate<Gadget>(gadgetPrefab);
        }
    }
}
