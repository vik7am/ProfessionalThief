using System;
using UnityEngine;
using UnityEngine.Events;
using ProfessionalThief.UI;

namespace ProfessionalThief.Util
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        public event Action onGameOver;
        public event Action<UserInterfaceID> onSwitchUI;

        public void ActivateAlarm(){
            Debug.Log("Game Over");
            onGameOver?.Invoke();
        }

        public void MissionCompleted(){
            onSwitchUI?.Invoke(UserInterfaceID.MISSION_COMPLETED);
        }

        public void MissionFailed(){
            onSwitchUI?.Invoke(UserInterfaceID.MISSION_FAILED);
        }
    }
}
