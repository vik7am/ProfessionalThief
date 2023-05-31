using UnityEngine;

namespace ProfessionalThief{
public class GateController : MonoBehaviour
{
    BoxCollider2D box;
    HudUI hudUI;

    void Awake(){
        box = GetComponent<BoxCollider2D>();
    }

    private void Start() {
        hudUI = UIManager.Instance.Hud;
    }

    public void OpenGate(){
        box.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        hudUI.UpdateItemInfo("Steal Gadget First");
    }

    private void OnCollisionExit2D(Collision2D other) {
        hudUI.UpdateItemInfo("");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance.LevelCompleted();
    }
}
}
