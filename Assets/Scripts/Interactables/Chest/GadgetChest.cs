using UnityEngine;
using ProfessionalThief.Items;
using UnityEngine.SceneManagement;

namespace ProfessionalThief.Interactables
{
    public class GadgetChest : Chest
    {
        [SerializeField] private Torch torch;
        [SerializeField] private StunGun stunGun;
        [SerializeField] private NightVisionGoggles nightVisionGoggles;
        private Gadget gadgetPrefab;


        protected override void InitializeItem(){
            base.InitializeItem();
            item.SetItemId((ItemId)gadgetPrefab.GadgetId);
        }

        private Gadget GetGadgetPrefab(){
            int currentLvel = GetCurrentLevel();
            switch(currentLvel){
                case 1 : return torch;
                case 2 : return stunGun;
                case 3 : return nightVisionGoggles;
                default : return null;
            }
        }

        private int GetCurrentLevel(){
            return SceneManager.GetActiveScene().buildIndex;
        }


        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Gadget";
        }

        public override void SetItemPrefab(){
            gadgetPrefab = GetGadgetPrefab();
            itemPrefab = gadgetPrefab.GetComponent<Item>();
        }
    }
}
