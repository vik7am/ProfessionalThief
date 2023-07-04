using UnityEngine;

namespace ProfessionalThief.Items
{
    public class StunGun : Gadget
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletFirePoint;
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge(){
            if(currentCharge <= maxCharge){
                RestoreCharge(Time.deltaTime);
            }
        }

        public override void UnEquip(){
            Deactivate();
        }

        protected override void Activate(){
            if(currentCharge < maxCharge) return;
            FireBullet();
            isActive = true;
        }

        private void FireBullet(){
            Instantiate(bulletPrefab, bulletFirePoint.position, transform.parent.rotation);
            ReduceCharge(maxCharge);
        }

        protected override void Deactivate(){
            isActive = false;
        }
    }
}
