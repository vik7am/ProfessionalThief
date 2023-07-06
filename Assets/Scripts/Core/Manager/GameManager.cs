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
        
        public static event Action<String> onGameOver;
        public static event Action<int> onLevelCompleted;
        public static event Action<bool> onGamePaused;
        public static event Action onMainObjectiveCompleted;

        private void OnEnable() {
            PlayerInventory.onGadgetAdded += CheckMainObjectiveStatus;
        }

        private void OnDisable() {
            PlayerInventory.onGadgetAdded -= CheckMainObjectiveStatus;
        }

        private Gadget GetGadgetPrefabForLevel(LevelName levelName){
            switch(levelName){
                case LevelName.LEVEL1 : return torch;
                case LevelName.LEVEL2 : return stunGun;
                case LevelName.LEVEL3 : return nightVisionGoggles;
                default : return null;
            }
        }

        private void CheckMainObjectiveStatus(Gadget gadget){
            LevelName currentLevelName = LevelManager.Instance.CurrentlevelName;
            Gadget targetGadget = GetGadgetPrefabForLevel(currentLevelName);
            if(gadget.GadgetId == targetGadget.GadgetId)
                onMainObjectiveCompleted?.Invoke();
        }

        public void GetGadgetForPreviousLevels(IItemInventory inventory){
            int currentLevel = LevelManager.Instance.CurrentLevelIndex;
            for(int i=currentLevel-1; i>0; i--){
                Gadget gadgetPrefab = GetGadgetPrefabForLevel((LevelName)i);
                Gadget gadget = Instantiate<Gadget>(gadgetPrefab);
                Item item = gadget.GetComponent<Item>();
                item.AddItemsToStack(1);
                item.SetItemId((ItemId)gadget.GadgetId);
                inventory.AddItem(item);
            }
        }

        public void ActivateAlarm(String detectorName){
            onGameOver?.Invoke(detectorName);
        }

        public void ExitBuilding(int totalItemValue){
            onLevelCompleted.Invoke(totalItemValue);
        }

        public void PauseGame() {
            onGamePaused.Invoke(true);
            Time.timeScale = 0;
        }
        
        public void ResumeGame() {
            onGamePaused.Invoke(false);
            Time.timeScale = 1;}
    }
}
