using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newspaperParticleSystem : MonoBehaviour {
    public GameObject spawn;
    public int amount;
    public float radius;
    private GameObject clone;
    public bool retry = false;
    public float force;
	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        if (retry) {
            Spawn();
            retry = false;
        }
	}

    void Spawn() {
        for (int i = 0; i < amount; i++) {
            clone = Instantiate(spawn, transform, true);
            clone.transform.position = (Random.insideUnitSphere * radius) + transform.position;
            clone.transform.rotation = Random.rotation;
            clone.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
