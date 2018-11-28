using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWalkingDogAI : AIParentScript {
    public bool AlreadyHit = false;
	// Use this for initialization
	void Awake () {
        AlreadyHit = false;
        stars.SetActive(false);
        angrySign.SetActive(false);
        this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }

    public void Chase()
    {
        if (AlreadyHit == false)
        {
            angrySign.SetActive(true);
            stars.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }
    }
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            AlreadyHit = true;
            stars.SetActive(true);
            angrySign.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bike")
        {
            Debug.Log("Death or salary decrease");
            AlreadyHit = true;
            stars.SetActive(true);
            angrySign.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
        else
        {
            Debug.Log(other.gameObject);
        }
    }
}
