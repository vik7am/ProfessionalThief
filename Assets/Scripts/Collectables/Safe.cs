using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief
{

    public abstract class Safe : MonoBehaviour
    {
        protected bool isLocked;
        protected ICollectable collectable;

        private void Start(){
            isLocked = true;
        }

        public bool IsLocked(){ return isLocked; }

        public void Unlock() { 
            isLocked = false; 
            InitializeCollectable();
        }

        public abstract void InitializeCollectable();

        public ICollectable GetCollectable(){
            return collectable;
        }
    }

    

    
}
