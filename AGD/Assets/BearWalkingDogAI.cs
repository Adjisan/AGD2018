using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWalkingDogAI : AIParentScript {
    public bool AlreadyHit = false;
    public float destroyTime = 3;
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
            Destroy(gameObject, destroyTime);
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Death or salary decrease");
            AlreadyHit = true;
            stars.SetActive(true);
            angrySign.SetActive(false);
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(gameObject, destroyTime);
        }
        else
        {
            Debug.Log(other.gameObject);
        }
    }
}
