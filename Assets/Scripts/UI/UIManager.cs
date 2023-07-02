using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ProfessionalThief.Util;

namespace ProfessionalThief.UI
{
    public enum UI_ID {HUD, MISSION_COMPLETED, MISSION_FAILED}

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private HUDUI hudUI;
        [SerializeField] private MissionCompletedUI missionCompletedUI;
        [SerializeField] private MissionFailedUI missionFailedUI;
        private GameObject activeUI;

        private void Start(){
            SwitchUI(UI_ID.HUD);
        }

        private void OnEnable() {
            GameManager.onGameOver += OnGameOver;
            GameManager.onMissionCompleted += OnMissionCompleted;
        }

        private void OnDisable() {
            GameManager.onGameOver -= OnGameOver;
            GameManager.onMissionCompleted -= OnMissionCompleted;
        }

        private void OnMissionCompleted(){
            SwitchUI(UI_ID.MISSION_COMPLETED);
        }

        private void OnGameOver(){
            SwitchUI(UI_ID.MISSION_FAILED);
        }

        public void SwitchUI(UI_ID userInterfaceID){
            if(activeUI != null)
                activeUI.SetActive(false);
            switch(userInterfaceID){
                case UI_ID.HUD : activeUI = hudUI.gameObject; break;
                case UI_ID.MISSION_COMPLETED : activeUI = missionCompletedUI.gameObject; break;
                case UI_ID.MISSION_FAILED : activeUI = missionFailedUI.gameObject; break;
            }
            activeUI.SetActive(true);
        }
    }
}
