using System;
using UnityEngine;
using UnityEngine.Events;
using ProfessionalThief.UI;
using ProfessionalThief.Player;
using ProfessionalThief.Item;

namespace ProfessionalThief.Util
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        public event Action onGameOver;
        public event Action onMissionCompleted;
        //public event Action<UserInterfaceID> onSwitchUI;
        public event Action onMainObjectiveCompleted;

        private void Start() {
            Inventory.onGadgetAdded += OnGadgetAdded;
        }

        private void OnGadgetAdded(Gadget gadget)
        {
            if(gadget.id == GadgetId.TORCH)
                onMainObjectiveCompleted?.Invoke();
        }

        public void ActivateAlarm(){
            Debug.Log("Game Over");
            onGameOver?.Invoke();
            Time.timeScale = 0;
        }

        public void MissionCompleted(){
            Time.timeScale = 0;
            onMissionCompleted.Invoke();
        }
    }
}
