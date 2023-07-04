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

    public abstract class Item : MonoBehaviour
    {
        public ItemId itemId;
        public ItemType itemType;
        public ItemId ItemId => itemId;
        public ItemType ItemType => itemType;
    }
}
