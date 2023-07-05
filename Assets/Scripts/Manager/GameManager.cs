using System;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using ProfessionalThief.Interactables;

namespace ProfessionalThief.Core
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        [SerializeField] private Torch torch;
        [SerializeField] private StunGun stunGun;
        [SerializeField] private NightVisionGoggles nightVisionGoggles;
        [SerializeField] private GadgetChest gadgetChest;
        
        public static event Action onGameOver;
        public static event Action onLevelCompleted;
        public static event Action onMainObjectiveCompleted;

        private void OnEnable() {
            PlayerInventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnDisable() {
            PlayerInventory.onGadgetAdded -= OnGadgetAdded;
        }

        public void GetGadgetForPreviousLevels(PlayerInventory playerInventory){
            int currentLevel = LevelManager.Instance.CurrentLevelIndex;
            for(int i=currentLevel-1; i>0; i--){
                Gadget gadgetPrefab = GetGadgetPrefabForLevel((LevelName)i);
                Gadget gadget = Instantiate<Gadget>(gadgetPrefab);
                Item item = gadget.GetComponent<Item>();
                item.AddItemsToStack(1);
                item.SetItemId((ItemId)gadget.GadgetId);
                playerInventory.AddItem(item);
            }
        }

        private Gadget GetGadgetPrefabForLevel(LevelName levelName){
            switch(levelName){
                case LevelName.LEVEL1 : return torch;
                case LevelName.LEVEL2 : return stunGun;
                case LevelName.LEVEL3 : return nightVisionGoggles;
                default : return null;
            }
        }

        private void OnGadgetAdded(Gadget gadget){
            LevelName currentLevelName = LevelManager.Instance.CurrentlevelName;
            Gadget targetGadget = GetGadgetPrefabForLevel(currentLevelName);
            if(gadget.GadgetId == targetGadget.GadgetId)
                onMainObjectiveCompleted?.Invoke();
        }

        public void ActivateAlarm(){
            onGameOver?.Invoke();
        }

        public void ExitBuilding(){
            onLevelCompleted.Invoke();
        }

        public void PauseGame() {Time.timeScale = 0;}
        public void ResumeGame() {Time.timeScale = 1;}
    }
}
