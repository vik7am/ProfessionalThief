using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]List<Transform> location;
    int nextLocation;
    Vector3 targetLocation;
    [SerializeField] float speed;

    void Start()
    {
        nextLocation = 0;
        targetLocation = GetNextLocation();
        RotateEnemy();
    }

    Vector3 GetNextLocation(){
        nextLocation++;
        nextLocation = nextLocation % location.Count;
        return location[nextLocation].position;
    }

    void RotateEnemy(){
        transform.right = targetLocation - transform.position;
    }

    void Update()
    {
        Vector2 delta = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
        if(delta == new Vector2(transform.position.x, transform.position.y)){
            targetLocation =  GetNextLocation();
            RotateEnemy();
        }
        else
            transform.position = delta;
    }
}
