using UnityEngine;
using TMPro;
using ProfessionalThief.Interactables;

namespace ProfessionalThief.UI
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactionPanel;
        [SerializeField] private TextMeshProUGUI interactionMessage;

        public void SetInteractionMessage(IInteractable interactable){
            interactionMessage.text = interactable.InteractionMessage();
        }
    }
}
