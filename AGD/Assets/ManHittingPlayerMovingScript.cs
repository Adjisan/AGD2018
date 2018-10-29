using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHittingPlayerMovingScript : MonoBehaviour {
    
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    GameObject mailBox;
    public Animator animator;
    public TrailRenderer renderer;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("playerObj").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mailBox = GameObject.FindGameObjectWithTag("MailBox");

        animator = this.GetComponentInChildren<Animator>();
        animator.SetBool("IsConfused", false);

        renderer = this.GetComponentInChildren<TrailRenderer>();
        renderer.enabled = false;
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
            animator.SetBool("IsConfused", true);
            renderer.enabled = true;
            Debug.Log("destroy");
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject);
        }
    }
}
