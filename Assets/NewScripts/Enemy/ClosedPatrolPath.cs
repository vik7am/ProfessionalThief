using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProfessionalThief.Enemy
{
    public class ClosedPatrolPath : PatrolPath
    {
        private Queue<Vector2> waypointQueue;

        protected override void DrawLinesAroundWaypoints(){
            for(int i = 0; i<pathCount-1; i++){
                Gizmos.DrawLine(GetWaypointPosition(i), GetWaypointPosition(i+1));
            }
            Gizmos.DrawLine(GetWaypointPosition(0), GetWaypointPosition(pathCount-1));
        }

        public override Queue<Vector2> GetWaypointQueue()
        {
            waypointQueue = new Queue<Vector2>();
            for(int i=0; i<transform.childCount; i++){
                waypointQueue.Enqueue(transform.GetChild(i).position);
            }
            return waypointQueue;
        }
    }
}
