using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AmmoBus : MonoBehaviour
{
    private float speed = 10;
    public bool BusCanBeHit = true;
    public int ammoAmountGained = 10;
    public bool loop = true;
    public Color BusPathColor = Color.white;
    public Rigidbody rb;
    public List<GameObject> waypoints;
    public List<float> waypointSpeed;
    private AudioClip honk;
    public AudioClip hitSound;
    int currentWaypointSpeed = 0;
    int currentWaypoint = 0;
    private float waypointRadius = 1;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = waypointSpeed[currentWaypointSpeed];
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = BusPathColor;
        if (loop)
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
        else
        {
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                waypoints[i].GetComponent<Waypoint>().colorGizmo(BusPathColor);
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && BusCanBeHit)
        {
            if (GameObject.Find("GameManager") != null)
            {
                GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
                Debug.Log("Gained Ammo");
                gameManager.ammo += ammoAmountGained;
                gameManager.ammoCountText();
                BusCanBeHit = false;
                GetComponent<AudioSource>().clip = hitSound;
                GetComponent<AudioSource>().Play ();
                Destroy(collision.gameObject);
            }
        }
    }

    void Update()
    {
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count && !loop)
            {
                currentWaypoint = 0;
                currentWaypointSpeed = 0;
                Destroy(this.gameObject);
            }
            else if (currentWaypoint >= waypoints.Count && loop)
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
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}


