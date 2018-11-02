using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBus : MonoBehaviour
{
    public bool open = true;
    public Rigidbody rb;
    public GameObject[] waypoints;
    public float[] waypointSpeed;
    int currentWaypointSpeed = 0;
    int currentWaypoint = 0;
    public float speed;
    float waypointRadius = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = waypointSpeed[currentWaypointSpeed];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && open)
        {
            Debug.Log("Gained Ammo");
            open = false;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
        {
            currentWaypoint++;
            currentWaypointSpeed++;
            
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
                currentWaypointSpeed = 0;
                Destroy(this.gameObject);
                Debug.Log("Reached last waypoint");
            }
            speed = waypointSpeed[currentWaypointSpeed];
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
