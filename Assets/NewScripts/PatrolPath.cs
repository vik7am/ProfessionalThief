using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Patrol
{
    public class PatrolPath : MonoBehaviour
    {
        private Queue<Vector2> waypointQueue;
        protected int pathCount;
        [SerializeField] private bool isPathClosed;

        private void Awake() {
            pathCount = transform.childCount;
        }

        private void OnDrawGizmos() {
            pathCount = transform.childCount;
            DrawLinesAroundWaypoints();
        }

        private void DrawLinesAroundWaypoints(){
            for(int i = 0; i<pathCount-1; i++){
                Gizmos.DrawLine(GetWaypointPosition(i), GetWaypointPosition(i+1));
            }
            if(isPathClosed){
                Gizmos.DrawLine(GetWaypointPosition(0), GetWaypointPosition(pathCount-1));
            }
        }

        public Vector2 GetWaypointPosition(int index){
            return transform.GetChild(index).position;
        }

        public Queue<Vector2> GetWaypointQueue(){
            waypointQueue = new Queue<Vector2>();
            for(int i=0; i<transform.childCount; i++){
                waypointQueue.Enqueue(transform.GetChild(i).position);
            }
            if(isPathClosed)
                return waypointQueue;
            for(int i=transform.childCount-2; i>0; i--){
                waypointQueue.Enqueue(transform.GetChild(i).position);
            }
            return waypointQueue;
        }
    }
}
