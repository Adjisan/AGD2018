using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHittingPlayerMovingScript : AIParentScript
{

    public bool death = true;
    public int AmountWindowBearSteals = 3;

    // Use this for initialization
    void Awake () {
        stars.SetActive(false);
        angrySign.SetActive(true);
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject, destroyTime);
        }
        if (other.gameObject.tag == "Player")
        {
            if (AlreadyHit == false)
            { GM.SubtractAmmo(AmountWindowBearSteals); }
            AlreadyHit = true;
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(gameObject, destroyTime);
        }
        else
        {
           // Debug.Log(other.gameObject);
        }
        Physics.IgnoreCollision(GameObject.Find("FenceDoor").GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("FlatEnemySpawner").GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
    }
}
