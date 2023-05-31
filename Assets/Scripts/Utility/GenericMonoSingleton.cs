using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;
        public static T Instance { get => instance; }
        protected void Awake()
        {
            if(instance == null){
                instance = (T)this;
                DontDestroyOnLoad(this);
                return;
            }
            Destroy(this);
        }
    }
}
