using System;
using ProfessionalThief.Core;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProfessionalThief.CCTV
{
    public class CCTV : MonoBehaviour, IStunnable
    {
        [SerializeField] private PlayerDetector playerDetector;
        [SerializeField] private Light2D bodyLight;
        private CCTVRotation cCTVRotation;
        
        public PlayerDetector PlayerDetector => playerDetector;
        public Light2D BodyLight => bodyLight;
        public CCTVRotation CCTVRotation => cCTVRotation;

        public event Action onHitByStunBullet;

        private void Awake() {
            cCTVRotation = GetComponent<CCTVRotation>();
        }

        public void TakeStunDamage(){
            onHitByStunBullet?.Invoke();
        }
    }
}
