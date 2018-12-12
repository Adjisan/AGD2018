using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHittingScript : MonoBehaviour {
    public GameObject bear;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile" && bear.GetComponent<BearWalkingDogAI>().AlreadyHit == false)
        {
            bear.GetComponent<BearWalkingDogAI>().Chase();
            Destroy(other.gameObject);
        }
       
    }
}
