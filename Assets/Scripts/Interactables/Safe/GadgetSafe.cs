using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class GadgetSafe : Safe
    {
        [SerializeField] private Torch torch;
        [SerializeField] private StunGun stunGun;
        [SerializeField] private NightVisionGoggles nightVisionGoggles;
        private Gadget gadgetPrefab;

        public override void  InitializeCollectable() {
            gadgetPrefab =  GetGadgetForCurrentLevel();
            collectable = Instantiate<Gadget>(gadgetPrefab);
        }

        public Gadget GetGadgetForCurrentLevel(){
            int level = 1;
            switch(level){
                case 1 : return torch;
                case 2 : return stunGun;
                case 3 : return nightVisionGoggles;
                default : return null;
            }
        }
    }
}
