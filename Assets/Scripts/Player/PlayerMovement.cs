using UnityEngine;

namespace ProfessionalThief{
public class PlayerMovement : MonoBehaviour
{
    Vector2 velocity;
    Vector2 oldVelocity;
    Rigidbody2D body;
    [SerializeField] float speed;
    float x, y;
    Camera cam;
    bool movement;
    Animator animator;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = Camera.main;
        movement = true;
    }

    void Update()
    {
        if(!movement)
            return;
        GetPlayerInput();
        UpdatePlayerRotation();
    }

    void FixedUpdate() {
        body.velocity = velocity * speed;
    }

    void LateUpdate() {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y , -10);
    }

    void GetPlayerInput(){
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
        if(velocity.x == 0 && velocity.y == 0)
            animator.SetBool("walking", false);
        else
            animator.SetBool("walking", true);
    }

    void UpdatePlayerRotation(){
        if(oldVelocity == velocity)
            return;
        oldVelocity = velocity;
        if(velocity.x == 1)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if(velocity.x == -1)
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        else if(velocity.y == 1)
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        else if(velocity.y == -1)
            transform.localRotation = Quaternion.Euler(0, 0, -90);
    }

    public void StopMovement(){
        velocity = Vector2.zero;
        movement = false;
    }
}
}
