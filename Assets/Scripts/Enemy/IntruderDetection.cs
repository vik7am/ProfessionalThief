using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null){
            player.SetStopMovement(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null){
            player.SetStopMovement(false);
        }
    }
}
