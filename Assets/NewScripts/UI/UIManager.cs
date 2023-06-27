using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ProfessionalThief.Util;

namespace ProfessionalThief.UI
{
    public abstract class UserInterface : MonoBehaviour
    {
        public void ToggleUI(bool status){
            gameObject.SetActive(status);
        }
    }

    public enum UserInterfaceID {HUD, MISSION_COMPLETED, MISSION_FAILED}

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HUDUI hudUI;
        [SerializeField] private MissionCompletedUI missionCompletedUI;
        [SerializeField] private MissionFailedUI missionFailedUI;
        private UserInterface activeUI;

        private void Start(){
            RegisterForEvents();
            SwitchUI(UserInterfaceID.HUD);
        }

        private void RegisterForEvents(){
            GameManager.Instance.onSwitchUI += SwitchUI;
        }

        public void SwitchUI(UserInterfaceID userInterfaceID){
            if(activeUI != null)
                activeUI.ToggleUI(false);
            switch(userInterfaceID){
                case UserInterfaceID.HUD : activeUI = hudUI; break;
                case UserInterfaceID.MISSION_COMPLETED : activeUI = missionCompletedUI; break;
                case UserInterfaceID.MISSION_FAILED : activeUI = missionFailedUI; break;
            }
            activeUI.ToggleUI(true);
        }
    }
}
