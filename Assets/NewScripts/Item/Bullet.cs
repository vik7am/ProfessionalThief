using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Enemy;

namespace ProfessionalThief.Items
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float despawnTime;
        [SerializeField] float speed;
        private new Rigidbody2D rigidbody2D;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            rigidbody2D.velocity = speed * transform.right;
            Destroy(gameObject, despawnTime);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            IStunnable stunableEntity = other.GetComponent<IStunnable>();
            if(other.TryGetComponent<IStunnable>(out IStunnable stunnable)){
                stunnable.TakeStunDamage();
            }
            else if(other.TryGetComponent<PlayerDetector>(out PlayerDetector playerDetector)){
                return;
            }
            Destroy(gameObject);
        }
    }
}
