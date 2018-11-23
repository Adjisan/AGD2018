using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHittingPlayerMovingScript : AIParentScript {

    // Use this for initialization
    void Awake () {
        stars.SetActive(false);
        angrySign.SetActive(true);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject);
        }
        Physics.IgnoreCollision(GameObject.Find("FlatEnemySpawner").GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
    }
}
