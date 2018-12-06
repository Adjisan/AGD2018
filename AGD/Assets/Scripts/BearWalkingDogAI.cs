﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWalkingDogAI : AIParentScript
{

    public int amountWalkingBearSteals = 3;

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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "playerObj")
        {
            if (AlreadyHit == false)
            { GM.SubtractAmmo(amountWalkingBearSteals);
                if (loseNewspaperParticles != null)
                {
                    GameObject clone = Instantiate(loseNewspaperParticles, other.transform.position, transform.rotation, null);
                }
            }
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
