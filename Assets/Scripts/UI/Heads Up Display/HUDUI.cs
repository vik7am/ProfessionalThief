using UnityEngine;
using TMPro;
using ProfessionalThief.Player;
using ProfessionalThief.Items;
using ProfessionalThief.Interactables;
using System;
using UnityEngine.UI;

namespace ProfessionalThief.UI
{
    public class HUDUI : MonoBehaviour
    {
        [SerializeField] private GadgetUI gadgetUI;
        [SerializeField] private ActionLogUI actionLogUI;
        [SerializeField] private InteractionUI interactionUI;
        [SerializeField] private TextMeshProUGUI totalItemValueTextUI;
        [SerializeField] private Button buttonE;
        [SerializeField] private Button buttonT;
        [SerializeField] private Button button1;
        [SerializeField] private Button button2;
        [SerializeField] private Button button3;

        public static event Action<GadgetId> onGadgetSelected;
        public static event Action onUseGadget;
        public static event Action onItemInteraction;

        private void Start(){
            gadgetUI.gameObject.SetActive(false);
            interactionUI.gameObject.SetActive(false);
        }

        private void Awake() {
            buttonE.onClick.AddListener(UseInteraction);
            buttonT.onClick.AddListener(UseGadget);
            button1.onClick.AddListener(EquipTorch);
            button2.onClick.AddListener(EquipStunGun);
            button3.onClick.AddListener(EquipNightVision);
        }

        public void UseInteraction() => onItemInteraction?.Invoke();
        public void UseGadget() => onUseGadget?.Invoke();
        private void EquipTorch() => onGadgetSelected?.Invoke(GadgetId.TORCH);
        private void EquipStunGun() => onGadgetSelected?.Invoke(GadgetId.STUN_GUN);
        private void EquipNightVision() => onGadgetSelected?.Invoke(GadgetId.NIGHT_VISION_GOGGLES);

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
