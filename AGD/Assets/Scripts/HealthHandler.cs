using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour {
    public GameObject healthIndicator;

	// Use this for initialization
	void Start () {
        int counter = Globals.lives;
        for (int i = 0; i < counter; i++) {
            GameObject clone = Instantiate(healthIndicator, new Vector3(transform.position.x + i*transform.localScale.x, transform.position.y, transform.position.z), transform.rotation);
            clone.transform.parent = gameObject.transform;
            clone.transform.localScale = Vector3.one;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.childCount > Globals.lives) {

           
            Debug.Log(gameObject.transform.childCount);
            Destroy(transform.GetChild(gameObject.transform.childCount-1).gameObject);
            if (Globals.lives <= 0) {
                Globals.speed = 0;
            }
        }
	}
}
