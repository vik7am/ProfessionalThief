using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float despawnTime;
    [SerializeField] float speed;
    
    void Update()
    {
        if(despawnTime <= 0)
            Destroy(gameObject);
        else
            despawnTime -= Time.deltaTime;
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
