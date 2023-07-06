using UnityEngine;
using TMPro;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using ProfessionalThief.Interactables;

namespace ProfessionalThief.UI
{
    public class HUDUI : MonoBehaviour
    {
        [SerializeField] private GadgetUI gadgetUI;
        [SerializeField] private ActionLogUI actionLogUI;
        [SerializeField] private InteractionUI interactionUI;
        [SerializeField] private TextMeshProUGUI totalItemValueTextUI;

        private void Start(){
            gadgetUI.gameObject.SetActive(false);
            interactionUI.gameObject.SetActive(false);
        }

        private void OnEnable() {
            PlayerInventory.onTotalItemValueUpdated += OnTotalItemValueUpdated;
            GadgetController.onGadgetEquip += OnGadgetEquip;
            GadgetController.onGadgetUnEquip += OnGadgetUnEquip;
            Interactor.onNearInteractable += ToggleInteractionUI;
        }

        private void OnDisable() {
            PlayerInventory.onTotalItemValueUpdated -= OnTotalItemValueUpdated;
            GadgetController.onGadgetEquip -= OnGadgetEquip;
            GadgetController.onGadgetUnEquip -= OnGadgetUnEquip;
            Interactor.onNearInteractable -= ToggleInteractionUI;
        }

        private void OnTotalItemValueUpdated(int amountInDollar){
            totalItemValueTextUI.text = "$ " + amountInDollar;
        }

        public void OnGadgetEquip(Gadget gadget){
            gadgetUI.gameObject.SetActive(true);
            gadgetUI.OnGadgetEquip(gadget);
        }

        public void OnGadgetUnEquip(){
            gadgetUI.OnGadgetUnEquip();
            gadgetUI.gameObject.SetActive(false);
        }

        public void ToggleInteractionUI(IInteractable interactable){
            if(interactable == null){
                interactionUI.gameObject.SetActive(false);
                return;
            }
            interactionUI.gameObject.SetActive(true);
            interactionUI.SetInteractionMessage(interactable);
        }
    }
}
