using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProfessionalThief.Core;

namespace ProfessionalThief.Enemy
{
    public class Patroling : MonoBehaviour, IMovementInput
    {
        [SerializeField] private PatrolPath patrolPath;
        [SerializeField] private float stoppingDistance;
        private Vector2 currentWayPoint;
        private Vector2 nextWaypoint;
        private Vector2 movementInput;
        private Movement movement;
        private Queue<Vector2> waypointQueue;
        private bool isPatrollingActive;

        private void Awake() {
            movement = GetComponent<Movement>();
        }
        
        private void Start(){
            waypointQueue = patrolPath.GetWaypointQueue();
            currentWayPoint = nextWaypoint = waypointQueue.Peek();
            transform.position = currentWayPoint;
            UpdateWaypoint();
        }

        private void Update(){
            if(isPatrollingActive)
                CheckDestination();
        }

        private void CheckDestination(){
            if(Vector2.Distance(transform.position, nextWaypoint) < stoppingDistance)
                UpdateWaypoint();
        }

        private void UpdateWaypoint(){
            currentWayPoint = nextWaypoint;
            nextWaypoint = GetNextWaypoint();
            movementInput = nextWaypoint - currentWayPoint;
        }

        private Vector2 GetNextWaypoint(){
            Vector2 waypoint = waypointQueue.Dequeue();
            waypointQueue.Enqueue(waypoint);
            return waypoint;
        }

        public Vector2 GetMovementDirection(){
            return movementInput.normalized;
        }

        public void SetPatrollingActive(bool state){
            isPatrollingActive = state;
            movement.SetMovementActive(state);
        }
    }
}
