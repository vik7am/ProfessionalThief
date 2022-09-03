using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
