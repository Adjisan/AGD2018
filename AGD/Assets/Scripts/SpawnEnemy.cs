// This was made using the following tutorial https://www.youtube.com/watch?v=9KOHclqSmR4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    private float nextSpawnTime;
    public int spawnAmount = 1;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float Delay;
    private bool collide = false;
    private int spawned = 0;


    [SerializeField]
    AudioSource glass;

    private void Start()
    {
        spawned = 0;
    }

	// Update is called once per frame
	private void Update ()
    {
        Spawn();
        collide = false;
	}
    private void Spawn()
    {
        if (collide == true && spawned < spawnAmount)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(5,30,0), this.transform.rotation);
                enemy.transform.parent = gameObject.transform.parent;
                spawned++;
                StartCoroutine(Wait());
            }
           Debug.Log("SpawnOne: " + spawned + " spawnAmount: " + spawnAmount);
           glass.Play();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            collide = true;
            Destroy(other.gameObject);
        }
    }

}
