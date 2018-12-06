using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHittingScript : MonoBehaviour {
 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            this.GetComponentInChildren<BearWalkingDogAI>().Chase();
            Destroy(other.gameObject);
        }
       
    }
}
