using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief{
public class GateController : MonoBehaviour
{
    BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    public void OpenGate()
    {
        box.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("Complete Objective First");
    }

    private void OnCollisionExit2D(Collision2D other) {
        UIManager.Instance().UpdateItemInfo("");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.Instance().LevelCompleted();
    }
}
}
