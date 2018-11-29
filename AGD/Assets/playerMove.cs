using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class playerMove : MonoBehaviour
{
    private float speed = 10;
    public bool moving = true;
    public Color BusPathColor = Color.white;
    public List<GameObject> waypoints;
    public List<float> waypointSpeed;
    int currentWaypointSpeed = 0;
    int currentWaypoint = 0;
    private float waypointRadius = 1;
    void Start()
    {
        if (moving)
        {
            speed = waypointSpeed[currentWaypointSpeed];
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = BusPathColor;
        if (moving)
        {
            for (int i = 0; i <= waypoints.Count - 1; i++)
            {
                if (i == waypoints.Count - 1)
                {
                    Gizmos.DrawLine(waypoints[waypoints.Count - 1].transform.position, waypoints[0].transform.position);
                }
                else
                {
                    Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
                }
                waypoints[i].GetComponent<Waypoint>().colorGizmo(BusPathColor);
            }
        }
        else if (moving)
        {
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                waypoints[i].GetComponent<Waypoint>().colorGizmo(BusPathColor);
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }
        }
    }

    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
            {
                currentWaypoint++;
                if (currentWaypoint >= waypoints.Count)
                {
                //    currentWaypoint = 0;
                    currentWaypointSpeed = 0;
                }
                else if (currentWaypoint >= waypoints.Count)
                {
                    currentWaypoint = 0;
                }
                speed = waypointSpeed[currentWaypointSpeed];
                currentWaypointSpeed++;
                if (currentWaypointSpeed == waypoints.Count)
                {
                    currentWaypointSpeed = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
            // rotation
            Vector3 relativePos = waypoints[currentWaypoint].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = rotation;
        }
    }
}


