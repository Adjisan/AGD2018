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
    private GameObject gameManager;

    public int ammoAmount = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = waypointSpeed[currentWaypointSpeed];

        if (GameObject.Find("GameManager") != null) {
            gameManager = GameObject.Find("GameManager");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && open)
        {
            Debug.Log("Gained Ammo");
            gameManager.GetComponent<GameManagerScript>().ammo += ammoAmount;
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

        Vector3 relativePos = waypoints[currentWaypoint].transform.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
