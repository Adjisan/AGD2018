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
    private int spawnOne = 0;

    [SerializeField]
    AudioSource glass;

    private void Start()
    {
        spawnOne = 0;
    }

	// Update is called once per frame
	private void Update ()
    {
        if (ShouldSpawn())
        {
                Spawn();
                Debug.Log(spawnOne);
          
        }
        collide = false;
	}
    private void Spawn()
    {
        nextSpawnTime = Time.time + Delay;

        if (collide == true && spawnOne == 0)
        {
           GameObject enemy = Instantiate(enemyPrefab, transform.position, this.transform.rotation);
           enemy.transform.parent = gameObject.transform.parent;
           spawnOne = 1;
            Debug.Log("SpawnOne: " + spawnOne);
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
