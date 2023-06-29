using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

namespace ProfessionalThief.Items
{
    public class StunGun : Gadget
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletFirePoint;

        protected override void Start() {
            base.Start();
        }
        
        private void Update(){
            UpdateCharge();
        }

        private void UpdateCharge(){
            if(currentCharge <= maxCharge){
                RestoreCharge(Time.deltaTime);
            }
        }

        public override void Equip(){
        }

        public override void UnEquip(){
            Deactivate();
        }

        protected override void Activate(){
            if(currentCharge < maxCharge) return;
            FireBullet();
            IsActive = true;
        }

        private void FireBullet(){
            Instantiate(bulletPrefab, bulletFirePoint.position, transform.parent.rotation);
            ReduceCharge(maxCharge);
        }

        protected override void Deactivate(){
            IsActive = false;
        }
    }
}
