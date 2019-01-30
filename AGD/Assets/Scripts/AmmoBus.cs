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
    public bool moving = true;
    public float timeLeft = 1;
    public float wobbleSpeed = 1;
    public Color BusPathColor = Color.white;
    public Rigidbody rb;
    public SetAmmoText ammoManager;
    public List<GameObject> waypoints;
    public List<float> waypointSpeed;
    private AudioClip honk;
    public AudioClip hitSound;
    int currentWaypointSpeed = 0;
    public int currentWaypoint = 0;
    private float waypointRadius = 10;
    public GameObject newspaperParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (moving)
        {
            speed = waypointSpeed[currentWaypointSpeed];
        }
        //        GetComponent<AudioSource>().playOnAwake = false;
     GameObject.Find("Bike").GetComponent<Animator>().SetFloat("wobbleSpeed", wobbleSpeed);        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = BusPathColor;
        if (loop && moving)
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
        else if (!loop && moving)
        {
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                waypoints[i].GetComponent<Waypoint>().colorGizmo(BusPathColor);
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && BusCanBeHit)
        {
 //           if (GameObject.Find("GameManager") != null)
    //        {
                Debug.Log("Gained Ammo");
                ammoManager.AddAmmo(ammoAmountGained);
                SpawnNewspaper();
                GetComponent<AudioSource>().clip = hitSound;
                GetComponent<AudioSource>().Play();
                BusCanBeHit = false;
                Destroy(collision.gameObject);
       //     }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Bike Collision");
        }
    }
    void Update()
    {
        if (moving)
        {
            if (Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position) < waypointRadius)
            {
                wobbleSpeed = 1 + (Globals.speed/100);
                GameObject.Find("Bike").GetComponent<Animator>().SetFloat("wobbleSpeed", wobbleSpeed);

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
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * (Globals.speed + speed));
            // Smooth rotation
            Vector3 relativePos = waypoints[currentWaypoint].transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), Time.deltaTime * 2);

        }
    }
    void SpawnNewspaper() {
        if (newspaperParticle == null) { Debug.Log("no newspaperParticle assigned to Ammobus"); return;} 
        if (ammoAmountGained > 0) {
            for (int i = 0; i < ammoAmountGained; i++) {
                GameObject clone = Instantiate(newspaperParticle, transform.position, Quaternion.AngleAxis(Random.Range(0.0f, 360.0f),Vector3.forward));
            }
        }
    }
}


