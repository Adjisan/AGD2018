using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    public GameObject arrow;
    public GameObject bigArrow;
    public int replaceAmount;
    public List<GameObject> replaceWaypoints;
    public List<GameObject> waypoints;
    public bool stopLightHit;
    public bool right;
    public int changeDirection;
    public int startDirection;
    public AudioClip hitSound;
    // Use this for initialization
    void Start()
    {
        if(startDirection == 0)
        {
            arrow.transform.Rotate(0,0,-90);
            bigArrow.transform.Rotate(0,0,-90);
        } else if (startDirection == 1)
        {
            arrow.transform.Rotate(0,0,0);
            bigArrow.transform.Rotate(0,0,0);
        }
        else if (startDirection == 2)
        {
            arrow.transform.Rotate(0,0,90);
            bigArrow.transform.Rotate(0,0,90);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile")
        {
            stopLightHit = !stopLightHit;

            if (GameObject.Find("Player") != null)
            {
                if (stopLightHit)
                {
                    if (changeDirection == 0)
                    {
                        arrow.transform.Rotate(0, 0, -90);
                        bigArrow.transform.Rotate(0, 0, -90);
                    }
                    else if (changeDirection == 1)
                    {
                        arrow.transform.Rotate(0, 0, 90);
                        bigArrow.transform.Rotate(0, 0, 90);
                    }
                    else if (changeDirection == 2)
                    {
                        arrow.transform.Rotate(0, 0, -180);
                        bigArrow.transform.Rotate(0, 0, -180);
                    }
                    else if (changeDirection == 3)
                    {
                        arrow.transform.Rotate(0, 0, 180);
                        bigArrow.transform.Rotate(0, 0, 180);
                    }
                    AmmoBus player = GameObject.Find("Player").GetComponent<AmmoBus>();
                    Debug.Log("StopLight Hit True");
                    replaceWaypoints = player.waypoints.GetRange(player.currentWaypoint, replaceAmount);
                    player.waypoints.RemoveRange(player.currentWaypoint, replaceAmount);
                    player.waypoints.InsertRange(player.currentWaypoint, waypoints);
                    player.waypoints[player.currentWaypoint] = waypoints[0];
                }
                else if (!stopLightHit)
                {
                    if (changeDirection == 0)
                    {
                        arrow.transform.Rotate(0, 0, 90);
                        bigArrow.transform.Rotate(0, 0, 90);
                    }
                    else if (changeDirection == 1)
                    {
                        arrow.transform.Rotate(0, 0, -90);
                        bigArrow.transform.Rotate(0, 0, -90);
                    }
                    else if (changeDirection == 2)
                    {
                        arrow.transform.Rotate(0, 0, 180);
                        bigArrow.transform.Rotate(0, 0, 180);
                    }
                    else if (changeDirection == 3)
                    {
                        arrow.transform.Rotate(0, 0, -180);
                        bigArrow.transform.Rotate(0, 0, -180);
                    }
                    AmmoBus player = GameObject.Find("Player").GetComponent<AmmoBus>();
                    Debug.Log("StopLight Hit False");
                    player.waypoints.RemoveRange(player.currentWaypoint, waypoints.Count);
                    player.waypoints.InsertRange(player.currentWaypoint, replaceWaypoints);
                    player.waypoints[player.currentWaypoint] = replaceWaypoints[0];
                }
                GetComponent<AudioSource>().clip = hitSound;
                GetComponent<AudioSource>().Play();
                // Destroy(collision.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
