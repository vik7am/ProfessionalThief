using UnityEngine;

namespace ProfessionalThief.Items
{
    public enum ItemType{
        VALUABLE,
        GADGET
    }

    public enum ItemId{
        VALUABLE_CASH,
        VALUABLE_SILVER_COIN,
        VALUABLE_GOLD_COIN,
        GADGET_TORCH,
        GADGET_STUN_GUN,
        GADGET_NIGHT_VISION_GOGGLES
    }

    public interface IItemInventory{
        void AddItem(Item item);
    }

    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        private ItemId itemId;
        private int stackSize;
        public ItemId ItemId => itemId;
        public ItemType ItemType => itemType;
        public int StackSize => stackSize;

        private void Awake() {
            stackSize = 0;
        }

        public void SetItemId(ItemId itemId){
            this.itemId = itemId;
        }

        public void AddItemsToStack(int quantity){
            stackSize += quantity;
        }
    }
}
