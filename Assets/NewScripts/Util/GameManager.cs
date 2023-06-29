using System;
using UnityEngine;
using ProfessionalThief.Player;
using ProfessionalThief.Items;

namespace ProfessionalThief.Util
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        public static event Action onGameOver;
        public static event Action onMissionCompleted;
        public static event Action onMainObjectiveCompleted;

        private void Start() {
            Inventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnGadgetAdded(Gadget gadget){
            if(gadget.itemId == ItemId.GADGET_TORCH)
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
