using UnityEngine.SceneManagement;

namespace ProfessionalThief.Core
{
    public enum LevelName {MAIN_MENU, LEVEL1, LEVEL2, LEVEL3}

    public class LevelManager : GenericMonoSingleton<LevelManager>
    {
        private int levelCount;
        private int currentLevelIndex;

        public int LevelCount => levelCount;
        public int CurrentLevelIndex => currentLevelIndex;
        public LevelName CurrentlevelName => (LevelName)currentLevelIndex;

        protected override void Awake() {
            base.Awake();
            levelCount = SceneManager.sceneCountInBuildSettings;
            currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void LoadLevel(int index){
            SceneManager.LoadScene(index);
        }

        public void LoadMainMenu(){
            currentLevelIndex = 0;
            LoadLevel(currentLevelIndex);
        }

        public void LoadNextLevel(){
            currentLevelIndex = GetNextLevelIndex();
            LoadLevel(currentLevelIndex);
        }

        public void ReloadCurrentLevel(){
            LoadLevel(currentLevelIndex);
        }

        public int GetNextLevelIndex(){
            if(currentLevelIndex == levelCount-1)
                return 0;
            return currentLevelIndex+1;
        }
    }
}
