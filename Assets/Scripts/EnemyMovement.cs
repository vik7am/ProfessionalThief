using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]List<Transform> paths;
    List<Vector3> location;
    int nextLocation;
    Vector3 targetLocation;
    [SerializeField] float speed;

    void Start()
    {
        location = new List<Vector3>();
        for(int i = 0; i < paths.Count; i++)
            location.Add(paths[i].position);
        nextLocation = 0;
        targetLocation = GetNextLocation();
    }

    Vector3 GetNextLocation(){
        nextLocation++;
        nextLocation = nextLocation % location.Count;
        /*if(nextLocation % 2 == 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);*/
        return location[nextLocation];
    }

    void Update()
    {
        Vector2 delta = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
        if(delta == new Vector2(transform.position.x, transform.position.y)){
            targetLocation =  GetNextLocation();
            transform.Rotate(0, 0, 180, Space.Self);
        }
        else
            transform.position = delta;
    }
}
