using UnityEngine;

namespace ProfessionalThief.Core
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;
        
        public static T Instance { get => instance; }

        protected virtual void Awake(){
            if(instance == null){
                instance = (T)this;
                DontDestroyOnLoad(this);
                return;
            }
            Destroy(this);
        }
    }
}
