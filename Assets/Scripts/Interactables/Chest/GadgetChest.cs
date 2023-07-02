using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using UnityEngine.SceneManagement;

namespace ProfessionalThief.Chest
{
    public class GadgetChest : Chest
    {
        [SerializeField] private Torch torch;
        [SerializeField] private StunGun stunGun;
        [SerializeField] private NightVisionGoggles nightVisionGoggles;
        private Gadget gadget;
        private Gadget gadgetPrefab;

        protected override void InitializeItem(){
            gadgetPrefab = GetGadgetPrefab();
            gadget = Instantiate<Gadget>(gadgetPrefab);
            gadget.transform.SetParent(transform);
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

        public override void Interact(Interactor interactor){
            if(isEmpty) return;
            Inventory inventory = interactor.GetComponent<Inventory>();
            if(inventory){
                inventory.AddGadget(gadget);
                isEmpty = true;
            }
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Gadget";
        }
    }
}