using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pathHolder;

    public float speed = 4f;
    public float waitTime = 1f;

    public bool retracePath = false;    // if set to true, enemy retraces its steps after going to each waypoint

    void Start()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }    

        if(waypoints.Length > 1)
        {
            StartCoroutine(FollowPath(waypoints));
        }
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        bool goingBackwards = false;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if(transform.position == targetWaypoint)
            {
                if (retracePath)
                {
                    if (!goingBackwards)
                    {
                        int nextIndex = targetWaypointIndex + 1;
                        if (nextIndex >= waypoints.Length)
                        {
                            goingBackwards = true;
                            targetWaypointIndex = targetWaypointIndex - 1;
                        }
                        else
                        {
                            targetWaypointIndex = nextIndex;
                        }
                    }
                    else
                    {
                        targetWaypointIndex = targetWaypointIndex - 1;
                        if(targetWaypointIndex < 0)
                        {
                            goingBackwards = false;
                            targetWaypointIndex = 1;
                        }
                    }
                    
                }
                else
                {
                    targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                }

                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()     // draws all the waypoints of the path this enemy will follow
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
    }


}
