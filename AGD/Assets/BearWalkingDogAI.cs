using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWalkingDogAI : AIParentScript {
    public bool AlreadyHit = false;
    public float survivalTime = 1000;
	// Use this for initialization
	void Awake () {
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
    private void Update()
    {
      //  survivalTime -= Time.deltaTime;
        if (survivalTime <= 0)
        {
            Debug.Log(survivalTime);
            //Destroy();
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
            Debug.Log("death or salary decrease");
            stars.SetActive(true);
            angrySign.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
        else
        {
            Debug.Log(other.gameObject);
        }
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
