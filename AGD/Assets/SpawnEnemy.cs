// This was made using the following tutorial https://www.youtube.com/watch?v=9KOHclqSmR4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    private float nextSpawnTime;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float Delay;
    private bool collide = false;

    [SerializeField]
    AudioSource glass;


	// Update is called once per frame
	private void Update ()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
        collide = false;
	}
    private void Spawn()
    {
        nextSpawnTime = Time.time + Delay;

        if (collide == true)
        {
           GameObject enemy = Instantiate(enemyPrefab, transform.position, this.transform.rotation);
           enemy.transform.parent = gameObject.transform.parent;

        }
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            glass.Play();
            collide = true;
            Destroy(other.gameObject);
        }
    }

}
