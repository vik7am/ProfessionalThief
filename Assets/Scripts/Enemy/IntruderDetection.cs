using UnityEngine;

namespace ProfessionalThief.V1{
public class IntruderDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null){
            GameManager.Instance().GameOver();
            player.StopMovement();
        }
    }
}
}
