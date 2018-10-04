using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject obj;
    public float startIn;
    public float interval;
    public GameObject parent;
    void Start() {
        InvokeRepeating("Spawn", startIn, interval);
    }
    private void Update() {
        if (Globals.lives <= 0) {
            CancelInvoke();
            if (gameObject.transform.childCount > 0) {
                Destroy(transform.GetChild(gameObject.transform.childCount - 1).gameObject);
            }
        }

    }
    void Spawn() {
        GameObject clone = Instantiate(obj, transform.position, transform.rotation);
        clone.transform.parent = parent.transform;
    }
}
