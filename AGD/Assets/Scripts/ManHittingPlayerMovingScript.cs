using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHittingPlayerMovingScript : MonoBehaviour {
    
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    GameObject mailBox;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject angrySign;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("playerObj").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mailBox = GameObject.FindGameObjectWithTag("MailBox");
        //stars = GameObject.FindGameObjectWithTag("star");
        angrySign = GameObject.FindGameObjectWithTag("AngrySign");
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
        //angrySign.SetActive(true);
    }
    public void Reset()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
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
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(true);
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
