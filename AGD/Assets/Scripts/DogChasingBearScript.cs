using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChasingBearScript : AIParentScript
{

    public int amountDogsSteal = 2;
    [SerializeField]
    private AudioSource dogAngry;
    [SerializeField]
    private AudioSource dogHit;
    [SerializeField]
    private AudioSource PlayerHurt;

    void Awake()
    {
        stars.SetActive(false);
        angrySign.SetActive(false);
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerObj" && AlreadyHit == false || other.gameObject.tag == "Player" && AlreadyHit == false)
        {
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            angrySign.SetActive(true);
            angrySign.transform.localScale = new Vector3(1, 1);
            dogAngry.Play();
        }
    }
   /* private void Update()
    {
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().angularSpeed = angularSpeed;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().acceleration = acceleration;
    } */
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject, destroyTime);
            AlreadyHit = true;
            dogHit.Play();
        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "playerObj")
        {
            if(AlreadyHit == false)
            {
                GM.ShakeScreen();
                PlayerHurt.Play();
                GM.SubtractAmmo(amountDogsSteal);
                if (loseNewspaperParticles != null)
                {
                    GameObject clone = Instantiate(loseNewspaperParticles, other.transform.position, transform.rotation, null);
                }
            }
            stars.SetActive(true);
            angrySign.SetActive(false);
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            AlreadyHit = true;
            Destroy(gameObject, destroyTime);
        }
     //   Physics.IgnoreCollision(GameObject.Find("FenceDoor").GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
     //   Physics.IgnoreCollision(GameObject.Find("FlatEnemySpawner").GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
    }
}
