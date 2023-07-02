using System;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using UnityEngine.SceneManagement;

namespace ProfessionalThief.Util
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        [SerializeField] private Torch torch;
        [SerializeField] private StunGun stunGun;
        [SerializeField] private NightVisionGoggles nightVisionGoggles;
        private Dictionary<int, Gadget> gadgetList;
        
        public static event Action onGameOver;
        public static event Action onMissionCompleted;
        public static event Action onMainObjectiveCompleted;

        private void Start() {
            Inventory.onGadgetAdded += OnGadgetAdded;
        }

        private void AddGadgetsToList(){
            gadgetList = new Dictionary<int, Gadget>();
            gadgetList.Add(1, torch);
            gadgetList.Add(2, stunGun);
            gadgetList.Add(3, nightVisionGoggles);
        }

        public void GetGadgetForPreviousLevels(GadgetController gadgetController){
            if(gadgetList == null)
                AddGadgetsToList();
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            for(int i=currentLevel-1; i>0; i--){
                Gadget gadget = Instantiate<Gadget>(gadgetList[i]);
                gadgetController.AddGadget(gadget);
            }
        }

        private void OnGadgetAdded(Gadget gadget){
            if(gadget.itemType == ItemType.GADGET)
                onMainObjectiveCompleted?.Invoke();
        }

        public void ActivateAlarm(){
            onGameOver?.Invoke();
            Time.timeScale = 0;
        }

        public void MissionCompleted(){
            Time.timeScale = 0;
            onMissionCompleted.Invoke();
        }
    }
}
