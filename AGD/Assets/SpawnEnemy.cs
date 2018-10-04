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
            Instantiate(enemyPrefab, transform.position, transform.rotation);
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
            collide = true;
        }
    }

}
