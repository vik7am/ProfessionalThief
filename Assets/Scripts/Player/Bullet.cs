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

    private void OnTriggerEnter2D(Collider2D other) {
        CCTVController cctv = other.GetComponent<CCTVController>();
        if(cctv != null){
            cctv.DisableCCTV();
            Destroy(gameObject);
            UIManager.Instance().UpdateActionLog("CCTV Disabled");
        }
        GaurdController gaurd = other.GetComponent<GaurdController>();
        if(gaurd != null){
            gaurd.DisableGaurd();
            Destroy(gameObject);
            UIManager.Instance().UpdateActionLog("Guard Incapacitated");
        }
    }
}
