using UnityEngine;

namespace ProfessionalThief.V1{
public class GateController : MonoBehaviour
{
    BoxCollider2D box;

    void Awake(){
        box = GetComponent<BoxCollider2D>();
    }

    public void OpenGate(){
        box.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("Steal Gadget First");
    }

    private void OnCollisionExit2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance().LevelCompleted();
    }
}
}
