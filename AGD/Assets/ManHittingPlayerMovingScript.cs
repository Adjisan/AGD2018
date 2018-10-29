using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHittingPlayerMovingScript : MonoBehaviour {
    
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    GameObject mailBox;
    public GameObject stars;
    public GameObject angrySign;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("playerObj").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mailBox = GameObject.FindGameObjectWithTag("MailBox");
        stars.SetActive(false);
        angrySign.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        
        if(gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled == true)
        {
            nav.SetDestination(player.position);
        }

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        { 
            Debug.Log("destroy");
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject);
        }
    }
}
