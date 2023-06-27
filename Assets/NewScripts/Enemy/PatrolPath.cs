using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Enemy
{
    public abstract class PatrolPath : MonoBehaviour
    {
        protected int pathCount;

        private void Awake() {
            pathCount = transform.childCount;
        }

         private void OnDrawGizmos() {
            pathCount = transform.childCount;
            DrawWaypoints();
            DrawLinesAroundWaypoints();
        }

        protected void DrawWaypoints() {
            for(int i = 0; i<pathCount; i++){
                Gizmos.DrawSphere(GetWaypointPosition(i), 0.2f);
            }
        }

        public Vector2 GetWaypointPosition(int index){
            return transform.GetChild(index).position;
        }

        protected virtual void DrawLinesAroundWaypoints(){}
        public abstract Queue<Vector2> GetWaypointQueue();

    }
}
