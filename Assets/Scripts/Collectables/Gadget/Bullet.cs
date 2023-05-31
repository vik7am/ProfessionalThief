using UnityEngine;

namespace ProfessionalThief{
public class Bullet : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float despawnTime;
    [SerializeField] float speed;
    private HudUI hudUI;

    private void Start() {
        hudUI = UIManager.Instance.Hud;    
    }

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
            if(cctv.IsActive()){
                cctv.DisableCCTV();
                hudUI.UpdateActionLog("CCTV Disabled");
            }
        }
        GuardController gaurd = other.GetComponent<GuardController>();
        if(gaurd != null){
            if(gaurd.IsActive()){
                gaurd.DisableGaurd();
                hudUI.UpdateActionLog("Guard Incapacitated");
            }
        }
        IntruderDetection intruderDetection = other.GetComponent<IntruderDetection>();
        if(intruderDetection != null){
            return;
        }
        Destroy(gameObject);
    }
}
}
