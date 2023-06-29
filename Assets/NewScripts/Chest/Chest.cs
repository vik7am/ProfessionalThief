using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Player;

namespace ProfessionalThief.Chest
{
    public interface IInteractableItem{
        void Interact(Interactor interactor);
        string InteractionMessage();
    }

    public abstract class Chest : MonoBehaviour, IInteractableItem
    {
        protected bool isEmpty;

        public bool IsEmpty => isEmpty;

        private void Start(){
            isEmpty = false;
            InitializeItem();
        }

        public abstract void Interact(Interactor interactor);
        public abstract string InteractionMessage();
        protected abstract void InitializeItem();
    }
}
