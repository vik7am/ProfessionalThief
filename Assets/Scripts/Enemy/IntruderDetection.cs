using UnityEngine;

namespace ProfessionalThief{
public class IntruderDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null){
            GameManager.Instance.GameOver();
            player.StopMovement();
        }
    }
}
}
