using UnityEngine;
using ProfessionalThief.Items;
using UnityEngine.SceneManagement;
using ProfessionalThief.Core;

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

        private Gadget GetGadgetPrefabForLevel(LevelName levelName){
            switch(levelName){
                case LevelName.LEVEL1 : return torch;
                case LevelName.LEVEL2 : return stunGun;
                case LevelName.LEVEL3 : return nightVisionGoggles;
                default : return null;
            }
        }

        public override string InteractionMessage(){
            if(isEmpty)
                return "Empty Chest";
            return "Press E to collect Gadget";
        }

        public override void SetItemPrefab(){
            LevelName currentLevelName = LevelManager.Instance.CurrentlevelName;
            gadgetPrefab = GetGadgetPrefabForLevel(currentLevelName);
            itemPrefab = gadgetPrefab.GetComponent<Item>();
        }
    }
}
