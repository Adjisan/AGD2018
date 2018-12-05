using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIParentScript : MonoBehaviour {
    public GameObject stars;
    public GameObject angrySign;
    protected UnityEngine.AI.NavMeshAgent nav;
    protected Transform player;
    protected float speed;
    public float speedIncrease = 1.2f;
    public float angularSpeed = 30.0f;
    public float acceleration = 80.0f;

    // Use this for initialization
    void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("playerObj").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled == true)
        {
            nav.SetDestination(player.position);
            Debug.Log("Globals speed: " + Globals.speed);
            speed = Globals.speed + speedIncrease;
            Debug.Log("acceleration: " + acceleration);
            nav.speed = Globals.speed + speedIncrease;
            nav.angularSpeed = Globals.speed + angularSpeed;
        }
    }


}
