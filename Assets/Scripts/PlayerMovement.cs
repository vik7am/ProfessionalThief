using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 velocity;
    Rigidbody2D body;
    [SerializeField] float speed;
    float x, y;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();
        UpdatePlayerRotation();
    }

    void FixedUpdate() {
        body.velocity = velocity * speed;
    }

    void GetPlayerInput(){
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    void UpdatePlayerRotation(){
        if(velocity.x == 1)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if(velocity.x == -1)
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        else if(velocity.y == 1)
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        else if(velocity.y == -1)
            transform.localRotation = Quaternion.Euler(0, 0, -90);
    }
}
