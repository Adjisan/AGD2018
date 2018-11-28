using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIParentScript : MonoBehaviour {
    public GameObject stars;
    public GameObject angrySign;
    protected UnityEngine.AI.NavMeshAgent nav;
    protected Transform player;
    public float destroyTime = 3;

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
            Debug.Log("walking");
        }

    }


}
